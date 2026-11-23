/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 08: BỘ TRIGGERS BẢO VỆ TOÀN VẸN & TỰ ĐỘNG HÓA HỆ THỐNG (TRIGGERS)
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Trigger: Bắt buộc chống trùng lịch suất chiếu tại cùng phòng chiếu (+15 phút dọn phòng)
CREATE OR ALTER TRIGGER dbo.trg_EnforceShowtimeOverlap
ON dbo.Showtimes
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @CleanBufferMinutes INT = 15;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN dbo.Showtimes s ON s.AuditoriumId = i.AuditoriumId
                                  AND s.ShowtimeId <> i.ShowtimeId
                                  AND s.IsDeleted = 0
                                  AND s.Status NOT IN ('Cancelled')
        WHERE i.IsDeleted = 0
          AND i.Status NOT IN ('Cancelled')
          AND (i.StartTime < DATEADD(MINUTE, @CleanBufferMinutes, s.EndTime) 
               AND DATEADD(MINUTE, @CleanBufferMinutes, i.EndTime) > s.StartTime)
    )
    BEGIN
        RAISERROR (N'Lỗi xung đột suất chiếu: Phòng chiếu này đã có lịch chiếu khác trong khoảng thời gian (bao gồm 15 phút dọn phòng)!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

-- 2. Trigger: Đảm bảo ghế được bán phải thuộc đúng phòng chiếu của suất chiếu & ghế không bị khóa
CREATE OR ALTER TRIGGER dbo.trg_ValidateTicketSeatAuditorium
ON dbo.Tickets
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra phòng chiếu của ghế và suất chiếu
    IF EXISTS (
        SELECT 1
        FROM inserted t
        INNER JOIN dbo.Showtimes st ON t.ShowtimeId = st.ShowtimeId
        INNER JOIN dbo.Seats s ON t.SeatId = s.SeatId
        WHERE s.AuditoriumId <> st.AuditoriumId
    )
    BEGIN
        RAISERROR (N'Lỗi toàn vẹn dữ liệu: Ghế được chọn không thuộc phòng chiếu của suất chiếu này!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra ghế có đang hoạt động không
    IF EXISTS (
        SELECT 1
        FROM inserted t
        INNER JOIN dbo.Seats s ON t.SeatId = s.SeatId
        WHERE s.IsActive = 0
    )
    BEGIN
        RAISERROR (N'Lỗi: Không thể bán vé cho ghế đang bị khóa/hỏng (IsActive = 0)!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

-- 3. Trigger: Tự động kiểm tra và trừ tồn kho bắp nước khi lên đơn
CREATE OR ALTER TRIGGER dbo.trg_AutoUpdateStockOnConcessionOrder
ON dbo.OrderConcessions
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra tồn kho trước khi trừ
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN dbo.Concessions c ON i.ConcessionId = c.ConcessionId
        WHERE c.StockQuantity < i.Quantity
    )
    BEGIN
        RAISERROR (N'Lỗi tồn kho: Mặt hàng bắp nước không đủ số lượng tồn để xuất bán!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Trừ số lượng tồn kho tự động
    UPDATE c
    SET c.StockQuantity = c.StockQuantity - i.Quantity,
        c.UpdatedAt = GETDATE()
    FROM dbo.Concessions c
    INNER JOIN inserted i ON c.ConcessionId = i.ConcessionId;
END;
GO

-- 4. Trigger: Tự động tích lũy điểm thưởng và nâng hạng thành viên khi đơn hàng thanh toán thành công
CREATE OR ALTER TRIGGER dbo.trg_AutoUpdateMembershipPointsOnPaidOrder
ON dbo.Orders
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(PaymentStatus)
    BEGIN
        UPDATE m
        SET m.TotalSpent = m.TotalSpent + i.FinalAmount,
            m.Points = m.Points + i.PointsEarned - i.PointsRedeemed,
            m.TierLevel = CASE 
                WHEN (m.TotalSpent + i.FinalAmount) >= 5000000 THEN N'Platinum'
                WHEN (m.TotalSpent + i.FinalAmount) >= 3000000 THEN N'Gold'
                WHEN (m.TotalSpent + i.FinalAmount) >= 1000000 THEN N'Silver'
                ELSE N'Standard'
            END,
            m.UpdatedAt = GETDATE()
        FROM dbo.Memberships m
        INNER JOIN inserted i ON m.MembershipId = i.MembershipId
        INNER JOIN deleted d ON i.OrderId = d.OrderId
        WHERE i.PaymentStatus = 'PAID' AND d.PaymentStatus <> 'PAID';
    END
END;
GO

-- 5. Trigger: Ghi nhật ký (Audit Log) khi Thêm / Sửa / Xóa Danh mục Phim
CREATE OR ALTER TRIGGER dbo.trg_AuditMovieChanges
ON dbo.Movies
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Action NVARCHAR(50);
    DECLARE @RecordId NVARCHAR(50);

    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        SET @Action = 'UPDATE';
        SELECT @RecordId = CAST(MovieId AS NVARCHAR(50)) FROM inserted;
        INSERT INTO dbo.AuditLogs (Action, TableName, RecordId, OldValues, NewValues, Timestamp)
        SELECT 'UPDATE', 'Movies', @RecordId, 
               (SELECT Title, Status, DurationMinutes FROM deleted FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               (SELECT Title, Status, DurationMinutes FROM inserted FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               GETDATE();
    END
    ELSE IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        SET @Action = 'INSERT';
        SELECT @RecordId = CAST(MovieId AS NVARCHAR(50)) FROM inserted;
        INSERT INTO dbo.AuditLogs (Action, TableName, RecordId, NewValues, Timestamp)
        SELECT 'INSERT', 'Movies', @RecordId,
               (SELECT Title, Status, DurationMinutes FROM inserted FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               GETDATE();
    END
    ELSE IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        SET @Action = 'DELETE';
        SELECT @RecordId = CAST(MovieId AS NVARCHAR(50)) FROM deleted;
        INSERT INTO dbo.AuditLogs (Action, TableName, RecordId, OldValues, Timestamp)
        SELECT 'DELETE', 'Movies', @RecordId,
               (SELECT Title, Status, DurationMinutes FROM deleted FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               GETDATE();
    END
END;
GO

PRINT N'>> [08_triggers.sql] Tạo thành công toàn bộ Triggers tự động hóa & bảo vệ toàn vẹn!';
GO
