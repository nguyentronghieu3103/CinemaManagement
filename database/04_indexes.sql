/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 04: CHỈ MỤC TỐI ƯU HÓA HIỆU NĂNG & FILTERED INDEXES (INDEXES)
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- ========================================================================================
-- 1. FILTERED UNIQUE INDEX: CHỐNG BÁN TRÙNG GHẾ (DOUBLE-BOOKING ENGINE)
-- ========================================================================================
CREATE UNIQUE NONCLUSTERED INDEX UQ_Tickets_Showtime_Seat_Active
ON dbo.Tickets (ShowtimeId, SeatId)
WHERE Status <> 'REFUNDED' AND Status <> 'CANCELLED';
GO

-- ========================================================================================
-- 2. CHỈ MỤC TỐI ƯU HÓA PHÉP NỐI KHÓA NGOẠI (FOREIGN KEY PERFORMANCE INDEXES)
-- ========================================================================================
CREATE NONCLUSTERED INDEX IX_Users_RoleId ON dbo.Users (RoleId);
CREATE NONCLUSTERED INDEX IX_Seats_AuditoriumId ON dbo.Seats (AuditoriumId);
CREATE NONCLUSTERED INDEX IX_Seats_SeatTypeId ON dbo.Seats (SeatTypeId);
CREATE NONCLUSTERED INDEX IX_Seats_Auditorium_Type ON dbo.Seats (AuditoriumId, SeatTypeId);

CREATE NONCLUSTERED INDEX IX_Showtimes_MovieId ON dbo.Showtimes (MovieId);
CREATE NONCLUSTERED INDEX IX_Showtimes_AuditoriumId ON dbo.Showtimes (AuditoriumId);

CREATE NONCLUSTERED INDEX IX_Orders_MembershipId ON dbo.Orders (MembershipId);
CREATE NONCLUSTERED INDEX IX_Orders_StaffUserId ON dbo.Orders (StaffUserId);

CREATE NONCLUSTERED INDEX IX_Tickets_OrderId ON dbo.Tickets (OrderId);
CREATE NONCLUSTERED INDEX IX_Tickets_ShowtimeId ON dbo.Tickets (ShowtimeId);
CREATE NONCLUSTERED INDEX IX_Tickets_SeatId ON dbo.Tickets (SeatId);

CREATE NONCLUSTERED INDEX IX_OrderConcessions_OrderId ON dbo.OrderConcessions (OrderId);
CREATE NONCLUSTERED INDEX IX_OrderConcessions_ConcessionId ON dbo.OrderConcessions (ConcessionId);

CREATE NONCLUSTERED INDEX IX_Shifts_UserId ON dbo.Shifts (UserId);
CREATE NONCLUSTERED INDEX IX_RefundRequests_OrderId ON dbo.RefundRequests (OrderId);
CREATE NONCLUSTERED INDEX IX_RefundRequests_TicketId ON dbo.RefundRequests (TicketId);
GO

-- ========================================================================================
-- 3. CHỈ MỤC TỔNG HỢP & BAO PHỦ (COMPOSITE & COVERING INDEXES CHO TRUY VẤN POS & WEB)
-- ========================================================================================
-- Lọc danh sách phim đang chiếu / sắp chiếu
CREATE NONCLUSTERED INDEX IX_Movies_Status_IsDeleted 
ON dbo.Movies (Status, IsDeleted) 
INCLUDE (Title, EnglishTitle, DurationMinutes, AgeRating, PosterUrl);

-- Tra cứu lịch chiếu theo phim & ngày chiếu (Dành cho màn hình chọn suất chiếu Web & POS)
CREATE NONCLUSTERED INDEX IX_Showtimes_Movie_Start 
ON dbo.Showtimes (MovieId, StartTime) 
INCLUDE (AuditoriumId, BasePrice, Status, EndTime);

-- Kiểm tra xung đột lịch phòng chiếu
CREATE NONCLUSTERED INDEX IX_Showtimes_Auditorium_Start 
ON dbo.Showtimes (AuditoriumId, StartTime, EndTime);

-- Báo cáo doanh thu theo ngày
CREATE NONCLUSTERED INDEX IX_Orders_OrderDate 
ON dbo.Orders (OrderDate) 
INCLUDE (SubTotal, DiscountAmount, FinalAmount, PaymentMethod, PaymentStatus);

-- Tra cứu ca làm việc theo nhân viên
CREATE NONCLUSTERED INDEX IX_Shifts_UserId_Status 
ON dbo.Shifts (UserId, Status) 
INCLUDE (StartTime, EndTime, InitialCash, TotalSales);

-- Tra cứu danh mục bắp nước theo phân loại
CREATE NONCLUSTERED INDEX IX_Concessions_Category_Active 
ON dbo.Concessions (Category, IsActive, IsDeleted) 
INCLUDE (Name, Unit, UnitPrice, StockQuantity);
GO

PRINT N'>> [04_indexes.sql] Tạo thành công toàn bộ Chỉ mục, Filtered Index và Composite Indexes!';
GO
