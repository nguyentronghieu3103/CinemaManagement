/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 06: THỦ TỤC LƯU TRỮ NGHIỆP VỤ (STORED PROCEDURES)
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Thủ tục kiểm tra xung đột lịch chiếu tại một phòng
CREATE OR ALTER PROCEDURE dbo.sp_CheckShowtimeOverlap
    @AuditoriumId INT,
    @StartTime DATETIME2(0),
    @EndTime DATETIME2(0),
    @ExcludeShowtimeId INT = 0,
    @IsOverlap BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @CleanBufferMinutes INT = 15;
    DECLARE @BufferEndTime DATETIME2(0) = DATEADD(MINUTE, @CleanBufferMinutes, @EndTime);

    IF EXISTS (
        SELECT 1 
        FROM dbo.Showtimes
        WHERE AuditoriumId = @AuditoriumId
          AND ShowtimeId <> @ExcludeShowtimeId
          AND IsDeleted = 0
          AND Status NOT IN ('Cancelled')
          AND (@StartTime < DATEADD(MINUTE, @CleanBufferMinutes, EndTime) AND @BufferEndTime > StartTime)
    )
    BEGIN
        SET @IsOverlap = 1;
    END
    ELSE
    BEGIN
        SET @IsOverlap = 0;
    END
END;
GO

-- 2. Thủ tục Thêm mới Suất Chiếu có kiểm tra phòng & tính giờ tự động
CREATE OR ALTER PROCEDURE dbo.sp_CreateShowtime
    @MovieId INT,
    @AuditoriumId INT,
    @StartTime DATETIME2(0),
    @BasePrice DECIMAL(18,2),
    @CreatedBy NVARCHAR(50),
    @NewShowtimeId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Lấy thời lượng phim
        DECLARE @Duration INT;
        SELECT @Duration = DurationMinutes FROM dbo.Movies WHERE MovieId = @MovieId AND IsDeleted = 0;

        IF @Duration IS NULL
        BEGIN
            RAISERROR (N'Phim không tồn tại hoặc đã bị xóa!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Tính giờ kết thúc tự động
        DECLARE @EndTime DATETIME2(0) = DATEADD(MINUTE, @Duration, @StartTime);

        -- Kiểm tra xung đột lịch
        DECLARE @IsOverlap BIT;
        EXEC dbo.sp_CheckShowtimeOverlap @AuditoriumId, @StartTime, @EndTime, 0, @IsOverlap OUTPUT;

        IF @IsOverlap = 1
        BEGIN
            RAISERROR (N'Phòng chiếu đã có lịch chiếu khác trong khoảng thời gian này (+15p dọn phòng)!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Thêm suất chiếu
        INSERT INTO dbo.Showtimes (MovieId, AuditoriumId, StartTime, EndTime, BasePrice, Status, CreatedBy)
        VALUES (@MovieId, @AuditoriumId, @StartTime, @EndTime, @BasePrice, N'Scheduled', @CreatedBy);

        SET @NewShowtimeId = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

-- 3. Thủ tục Hoàn Trả Vé (Ticket Refund) kèm kiểm tra điều kiện nghiệp vụ
CREATE OR ALTER PROCEDURE dbo.sp_ProcessTicketRefund
    @TicketId INT,
    @ProcessedByUserId INT,
    @RefundReason NVARCHAR(255),
    @Success BIT OUTPUT,
    @Message NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @OrderId INT, @ShowtimeId INT, @TicketPrice DECIMAL(18,2), @Status VARCHAR(30), @StartTime DATETIME2(0);

        SELECT 
            @OrderId = t.OrderId,
            @ShowtimeId = t.ShowtimeId,
            @TicketPrice = t.TicketPrice,
            @Status = t.Status,
            @StartTime = st.StartTime
        FROM dbo.Tickets t
        INNER JOIN dbo.Showtimes st ON t.ShowtimeId = st.ShowtimeId
        WHERE t.TicketId = @TicketId;

        -- Kiểm tra vé tồn tại
        IF @OrderId IS NULL
        BEGIN
            SET @Success = 0;
            SET @Message = N'Không tìm thấy thông tin vé!';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Kiểm tra trạng thái vé
        IF @Status <> 'ISSUED'
        BEGIN
            SET @Success = 0;
            SET @Message = N'Chỉ có thể hoàn vé ở trạng thái ISSUED (Chưa sử dụng)!';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Lấy thời gian tối thiểu trước giờ chiếu từ SystemConfigs
        DECLARE @MinMinutes INT = 60;
        SELECT @MinMinutes = TRY_CAST(ConfigValue AS INT) 
        FROM dbo.SystemConfigs 
        WHERE ConfigKey = 'MIN_MINUTES_BEFORE_REFUND';

        IF DATEDIFF(MINUTE, GETDATE(), @StartTime) < @MinMinutes
        BEGIN
            SET @Success = 0;
            SET @Message = N'Đã quá thời hạn cho phép hoàn vé (Phải trước giờ chiếu ít nhất ' + CAST(@MinMinutes AS NVARCHAR(10)) + N' phút)!';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Cập nhật trạng thái vé thành REFUNDED (Filtered index sẽ tự động nhả ghế)
        UPDATE dbo.Tickets
        SET Status = 'REFUNDED'
        WHERE TicketId = @TicketId;

        -- Ghi nhận yêu cầu hoàn tiền vào RefundRequests
        INSERT INTO dbo.RefundRequests (OrderId, TicketId, RefundReason, RefundAmount, RequestedAt, ProcessedByUserId, Status, Notes)
        VALUES (@OrderId, @TicketId, @RefundReason, @TicketPrice, GETDATE(), @ProcessedByUserId, 'APPROVED', N'Hoàn trả thành công tại quầy');

        -- Cập nhật lại đơn hàng
        UPDATE dbo.Orders
        SET FinalAmount = CASE WHEN FinalAmount >= @TicketPrice THEN FinalAmount - @TicketPrice ELSE 0 END,
            Notes = ISNULL(Notes + N'; ', N'') + N'Đã hoàn vé #' + CAST(@TicketId AS NVARCHAR(20))
        WHERE OrderId = @OrderId;

        SET @Success = 1;
        SET @Message = N'Hoàn vé thành công. Ghế đã được giải phóng để bán lại!';

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SET @Success = 0;
        SET @Message = ERROR_MESSAGE();
    END CATCH;
END;
GO

-- 4. Thủ tục Mở Ca Làm Việc (Open Shift)
CREATE OR ALTER PROCEDURE dbo.sp_OpenShift
    @UserId INT,
    @ShiftName NVARCHAR(50),
    @InitialCash DECIMAL(18,2),
    @Notes NVARCHAR(255) = NULL,
    @NewShiftId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra nhân viên có ca nào đang mở chưa
    IF EXISTS (SELECT 1 FROM dbo.Shifts WHERE UserId = @UserId AND Status = 'OPEN')
    BEGIN
        RAISERROR (N'Nhân viên này đang có một ca làm việc chưa kết thúc! Vui lòng kết ca trước.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.Shifts (UserId, ShiftName, StartTime, InitialCash, TotalSales, Status, Notes)
    VALUES (@UserId, @ShiftName, GETDATE(), @InitialCash, 0, 'OPEN', @Notes);

    SET @NewShiftId = SCOPE_IDENTITY();
END;
GO

-- 5. Thủ tục Kết Thúc Ca Làm Việc & Đối Soát Tiền (Close Shift)
CREATE OR ALTER PROCEDURE dbo.sp_CloseShift
    @ShiftId INT,
    @FinalCash DECIMAL(18,2),
    @Notes NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @InitialCash DECIMAL(18,2), @TotalSales DECIMAL(18,2), @StartTime DATETIME2(0), @UserId INT;

    SELECT 
        @InitialCash = InitialCash, 
        @StartTime = StartTime, 
        @UserId = UserId
    FROM dbo.Shifts 
    WHERE ShiftId = @ShiftId AND Status = 'OPEN';

    IF @StartTime IS NULL
    BEGIN
        RAISERROR (N'Không tìm thấy ca làm việc đang mở với ID này!', 16, 1);
        RETURN;
    END

    -- Tính tổng doanh thu tiền mặt phát sinh trong ca
    SELECT @TotalSales = ISNULL(SUM(FinalAmount), 0)
    FROM dbo.Orders
    WHERE StaffUserId = @UserId
      AND PaymentMethod = 'CASH'
      AND PaymentStatus = 'PAID'
      AND OrderDate >= @StartTime AND OrderDate <= GETDATE();

    -- Tính chênh lệch tiền: Tiền đếm được - (Tiền thối ban đầu + Tiền bán được)
    DECLARE @ExpectedCash DECIMAL(18,2) = @InitialCash + @TotalSales;
    DECLARE @CashDifference DECIMAL(18,2) = @FinalCash - @ExpectedCash;

    UPDATE dbo.Shifts
    SET EndTime = GETDATE(),
        TotalSales = @TotalSales,
        FinalCash = @FinalCash,
        CashDifference = @CashDifference,
        Status = 'CLOSED',
        Notes = ISNULL(@Notes, Notes)
    WHERE ShiftId = @ShiftId;
END;
GO

-- 6. Thủ tục Lấy Báo Cáo Doanh Thu Theo Khoảng Ngày
CREATE OR ALTER PROCEDURE dbo.sp_GetDailyRevenueReport
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CAST(o.OrderDate AS DATE) AS [Date],
        COUNT(DISTINCT o.OrderId) AS TotalOrders,
        COUNT(t.TicketId) AS TotalTickets,
        ISNULL(SUM(t.TicketPrice), 0) AS TicketRevenue,
        ISNULL(SUM(oc.TotalPrice), 0) AS ConcessionRevenue,
        ISNULL(SUM(o.DiscountAmount), 0) AS DiscountAmount,
        ISNULL(SUM(o.FinalAmount), 0) AS NetRevenue
    FROM dbo.Orders o
    LEFT JOIN dbo.Tickets t ON o.OrderId = t.OrderId AND t.Status NOT IN ('REFUNDED', 'CANCELLED')
    LEFT JOIN dbo.OrderConcessions oc ON o.OrderId = oc.OrderId
    WHERE o.PaymentStatus = 'PAID'
      AND CAST(o.OrderDate AS DATE) >= @FromDate 
      AND CAST(o.OrderDate AS DATE) <= @ToDate
    GROUP BY CAST(o.OrderDate AS DATE)
    ORDER BY [Date] DESC;
END;
GO

PRINT N'>> [06_procedures.sql] Tạo thành công toàn bộ 6 Stored Procedures nghiệp vụ!';
GO
