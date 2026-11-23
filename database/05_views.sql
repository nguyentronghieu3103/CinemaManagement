/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 05: KHUNG NHÌN BÁO CÁO & THỐNG KÊ (VIEWS)
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. View Chi tiết Phim kèm chuỗi Thể loại nối (STRING_AGG)
CREATE OR ALTER VIEW dbo.vw_MovieDetailsWithGenres
AS
SELECT 
    m.MovieId,
    m.Title,
    m.EnglishTitle,
    m.Director,
    m.Cast,
    m.DurationMinutes,
    m.ReleaseDate,
    m.EndDate,
    m.AgeRating,
    m.Language,
    m.Subtitle,
    m.PosterUrl,
    m.TrailerUrl,
    m.Description,
    m.Status,
    m.IsDeleted,
    STRING_AGG(g.GenreName, N', ') WITHIN GROUP (ORDER BY g.GenreName) AS GenreNames
FROM dbo.Movies m
LEFT JOIN dbo.MovieGenres mg ON m.MovieId = mg.MovieId
LEFT JOIN dbo.Genres g ON mg.GenreId = g.GenreId
GROUP BY 
    m.MovieId, m.Title, m.EnglishTitle, m.Director, m.Cast,
    m.DurationMinutes, m.ReleaseDate, m.EndDate, m.AgeRating,
    m.Language, m.Subtitle, m.PosterUrl, m.TrailerUrl,
    m.Description, m.Status, m.IsDeleted;
GO

-- 2. View Lịch chiếu chi tiết kèm số ghế trống thực tế
CREATE OR ALTER VIEW dbo.vw_ShowtimeSchedule
AS
SELECT 
    st.ShowtimeId,
    st.MovieId,
    m.Title AS MovieTitle,
    m.AgeRating,
    m.DurationMinutes,
    m.PosterUrl,
    st.AuditoriumId,
    a.Name AS AuditoriumName,
    a.ScreenType,
    a.TotalSeats,
    st.StartTime,
    st.EndTime,
    st.BasePrice,
    st.Status AS ShowtimeStatus,
    COUNT(CASE WHEN t.Status NOT IN ('REFUNDED', 'CANCELLED') THEN t.TicketId END) AS SoldTicketsCount,
    (a.TotalSeats - COUNT(CASE WHEN t.Status NOT IN ('REFUNDED', 'CANCELLED') THEN t.TicketId END)) AS AvailableSeatsCount
FROM dbo.Showtimes st
INNER JOIN dbo.Movies m ON st.MovieId = m.MovieId
INNER JOIN dbo.Auditoriums a ON st.AuditoriumId = a.AuditoriumId
LEFT JOIN dbo.Tickets t ON st.ShowtimeId = t.ShowtimeId
WHERE st.IsDeleted = 0 AND m.IsDeleted = 0
GROUP BY 
    st.ShowtimeId, st.MovieId, m.Title, m.AgeRating, m.DurationMinutes, m.PosterUrl,
    st.AuditoriumId, a.Name, a.ScreenType, a.TotalSeats,
    st.StartTime, st.EndTime, st.BasePrice, st.Status;
GO

-- 3. View Sơ đồ ghế và Trạng thái vé theo Suất chiếu
CREATE OR ALTER VIEW dbo.vw_SeatStatusByShowtime
AS
SELECT 
    st.ShowtimeId,
    s.AuditoriumId,
    s.SeatId,
    s.SeatRow,
    s.SeatNumber,
    s.SeatCode,
    stype.SeatTypeId,
    stype.TypeName AS SeatTypeName,
    stype.ColorCode AS SeatTypeColor,
    (st.BasePrice + stype.SurchargeAmount) AS CalculatedPrice,
    t.TicketId,
    CASE 
        WHEN t.TicketId IS NOT NULL AND t.Status NOT IN ('REFUNDED', 'CANCELLED') THEN N'BOOKED'
        WHEN s.IsActive = 0 THEN N'LOCKED'
        ELSE N'AVAILABLE'
    END AS SeatState,
    t.Barcode,
    t.Status AS TicketStatus
FROM dbo.Showtimes st
INNER JOIN dbo.Seats s ON st.AuditoriumId = s.AuditoriumId
INNER JOIN dbo.SeatTypes stype ON s.SeatTypeId = stype.SeatTypeId
LEFT JOIN dbo.Tickets t ON st.ShowtimeId = t.ShowtimeId 
                       AND s.SeatId = t.SeatId 
                       AND t.Status NOT IN ('REFUNDED', 'CANCELLED');
GO

-- 4. View Báo cáo Doanh thu Bán hàng theo Ngày
CREATE OR ALTER VIEW dbo.vw_DailySalesReport
AS
SELECT 
    CAST(o.OrderDate AS DATE) AS SalesDate,
    COUNT(DISTINCT o.OrderId) AS TotalOrdersCount,
    COUNT(t.TicketId) AS TotalTicketsSold,
    ISNULL(SUM(t.TicketPrice), 0) AS TotalTicketRevenue,
    ISNULL(SUM(oc.TotalPrice), 0) AS TotalConcessionRevenue,
    ISNULL(SUM(o.DiscountAmount), 0) AS TotalDiscounts,
    ISNULL(SUM(o.FinalAmount), 0) AS NetRevenue
FROM dbo.Orders o
LEFT JOIN dbo.Tickets t ON o.OrderId = t.OrderId AND t.Status NOT IN ('REFUNDED', 'CANCELLED')
LEFT JOIN dbo.OrderConcessions oc ON o.OrderId = oc.OrderId
WHERE o.PaymentStatus = 'PAID'
GROUP BY CAST(o.OrderDate AS DATE);
GO

-- 5. View Bảng xếp hạng Phim Ăn Khách Nhất (Top Selling Movies)
CREATE OR ALTER VIEW dbo.vw_TopSellingMovies
AS
SELECT 
    m.MovieId,
    m.Title,
    m.ReleaseDate,
    m.AgeRating,
    COUNT(t.TicketId) AS TotalTicketsSold,
    ISNULL(SUM(t.TicketPrice), 0) AS TotalBoxOfficeRevenue
FROM dbo.Movies m
INNER JOIN dbo.Showtimes st ON m.MovieId = st.MovieId
INNER JOIN dbo.Tickets t ON st.ShowtimeId = t.ShowtimeId AND t.Status NOT IN ('REFUNDED', 'CANCELLED')
GROUP BY m.MovieId, m.Title, m.ReleaseDate, m.AgeRating;
GO

-- 6. View Cảnh báo Tồn kho Bắp nước (Inventory Alert)
CREATE OR ALTER VIEW dbo.vw_ConcessionInventoryAlert
AS
SELECT 
    ConcessionId,
    Name,
    Category,
    Unit,
    UnitPrice,
    CostPrice,
    StockQuantity,
    CASE 
        WHEN StockQuantity <= 10 THEN N'NGUY CẤP'
        WHEN StockQuantity <= 30 THEN N'SẮP HẾT'
        ELSE N'BÌNH THƯỜNG'
    END AS StockLevelAlert
FROM dbo.Concessions
WHERE IsActive = 1 AND IsDeleted = 0;
GO

-- 7. View Tổng hợp Doanh số Ca làm việc của Nhân viên (Staff Shift Summary)
CREATE OR ALTER VIEW dbo.vw_StaffShiftSummary
AS
SELECT 
    s.ShiftId,
    s.ShiftName,
    u.UserId,
    u.FullName AS StaffName,
    s.StartTime,
    s.EndTime,
    s.InitialCash,
    s.TotalSales,
    s.FinalCash,
    s.CashDifference,
    s.Status AS ShiftStatus,
    COUNT(o.OrderId) AS OrdersProcessedCount
FROM dbo.Shifts s
INNER JOIN dbo.Users u ON s.UserId = u.UserId
LEFT JOIN dbo.Orders o ON s.UserId = o.StaffUserId 
                      AND o.OrderDate >= s.StartTime 
                      AND (s.EndTime IS NULL OR o.OrderDate <= s.EndTime)
                      AND o.PaymentStatus = 'PAID'
GROUP BY 
    s.ShiftId, s.ShiftName, u.UserId, u.FullName,
    s.StartTime, s.EndTime, s.InitialCash, s.TotalSales,
    s.FinalCash, s.CashDifference, s.Status;
GO

PRINT N'>> [05_views.sql] Tạo thành công 7 Khung nhìn (Views) nghiệp vụ & báo cáo!';
GO
