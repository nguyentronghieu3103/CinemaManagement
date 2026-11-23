/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 07: HÀM NGHIỆP VỤ & TÍNH TOÁN (FUNCTIONS)
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. Hàm tính Giá vé Chuẩn (BasePrice + Surcharge loại ghế)
CREATE OR ALTER FUNCTION dbo.fn_CalculateTicketPrice
(
    @ShowtimeId INT,
    @SeatId INT
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @BasePrice DECIMAL(18,2) = 0;
    DECLARE @Surcharge DECIMAL(18,2) = 0;

    -- Lấy giá gốc của suất chiếu
    SELECT @BasePrice = BasePrice 
    FROM dbo.Showtimes 
    WHERE ShowtimeId = @ShowtimeId;

    -- Lấy phụ thu theo loại ghế
    SELECT @Surcharge = st.SurchargeAmount
    FROM dbo.Seats s
    INNER JOIN dbo.SeatTypes st ON s.SeatTypeId = st.SeatTypeId
    WHERE s.SeatId = @SeatId;

    RETURN ISNULL(@BasePrice, 0) + ISNULL(@Surcharge, 0);
END;
GO

-- 2. Hàm xác định Hạng Thành Viên theo Tổng Chi Tiêu
CREATE OR ALTER FUNCTION dbo.fn_CalculateMembershipTier
(
    @TotalSpent DECIMAL(18,2)
)
RETURNS NVARCHAR(30)
AS
BEGIN
    IF @TotalSpent >= 5000000.00
        RETURN N'Platinum';
    IF @TotalSpent >= 3000000.00
        RETURN N'Gold';
    IF @TotalSpent >= 1000000.00
        RETURN N'Silver';
        
    RETURN N'Standard';
END;
GO

-- 3. Hàm đếm Số Ghế Còn Trống của Suất Chiếu
CREATE OR ALTER FUNCTION dbo.fn_GetAvailableSeatsCount
(
    @ShowtimeId INT
)
RETURNS INT
AS
BEGIN
    DECLARE @TotalSeats INT = 0;
    DECLARE @SoldSeats INT = 0;

    SELECT @TotalSeats = a.TotalSeats
    FROM dbo.Showtimes st
    INNER JOIN dbo.Auditoriums a ON st.AuditoriumId = a.AuditoriumId
    WHERE st.ShowtimeId = @ShowtimeId;

    SELECT @SoldSeats = COUNT(*)
    FROM dbo.Tickets
    WHERE ShowtimeId = @ShowtimeId 
      AND Status NOT IN ('REFUNDED', 'CANCELLED');

    RETURN (@TotalSeats - @SoldSeats);
END;
GO

-- 4. Hàm Table-Valued Function: Lấy Sơ Đồ Ghế & Trạng Thái Cho Giao Diện Bán Vé (WinForms/Web)
CREATE OR ALTER FUNCTION dbo.fn_GetAuditoriumSeatMap
(
    @ShowtimeId INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        s.SeatId,
        s.AuditoriumId,
        s.SeatRow,
        s.SeatNumber,
        s.SeatCode,
        st.TypeName AS SeatTypeName,
        st.ColorCode AS SeatTypeColor,
        st.SurchargeAmount,
        (show.BasePrice + st.SurchargeAmount) AS FinalPrice,
        s.IsActive AS IsSeatActive,
        CASE 
            WHEN s.IsActive = 0 THEN 'LOCKED'
            WHEN t.TicketId IS NOT NULL THEN 'BOOKED'
            ELSE 'AVAILABLE'
        END AS BookingStatus,
        t.Barcode,
        t.TicketId
    FROM dbo.Showtimes show
    INNER JOIN dbo.Seats s ON show.AuditoriumId = s.AuditoriumId
    INNER JOIN dbo.SeatTypes st ON s.SeatTypeId = st.SeatTypeId
    LEFT JOIN dbo.Tickets t ON show.ShowtimeId = t.ShowtimeId 
                           AND s.SeatId = t.SeatId 
                           AND t.Status NOT IN ('REFUNDED', 'CANCELLED')
    WHERE show.ShowtimeId = @ShowtimeId
);
GO

-- 5. Hàm Table-Valued Function: Lịch Sử Mua Vé của Thành Viên
CREATE OR ALTER FUNCTION dbo.fn_GetCustomerBookingHistory
(
    @MembershipId INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        o.OrderId,
        o.OrderCode,
        o.OrderDate,
        m.Title AS MovieTitle,
        a.Name AS AuditoriumName,
        st.StartTime,
        s.SeatCode,
        t.TicketPrice,
        t.Status AS TicketStatus,
        o.FinalAmount AS TotalOrderAmount,
        o.PaymentMethod
    FROM dbo.Orders o
    INNER JOIN dbo.Tickets t ON o.OrderId = t.OrderId
    INNER JOIN dbo.Showtimes st ON t.ShowtimeId = st.ShowtimeId
    INNER JOIN dbo.Movies m ON st.MovieId = m.MovieId
    INNER JOIN dbo.Auditoriums a ON st.AuditoriumId = a.AuditoriumId
    INNER JOIN dbo.Seats s ON t.SeatId = s.SeatId
    WHERE o.MembershipId = @MembershipId
);
GO

PRINT N'>> [07_functions.sql] Tạo thành công toàn bộ các Hàm (Functions) nghiệp vụ!';
GO
