/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 03: RÀNG BUỘC TOÀN VẸN (CONSTRAINTS: FK, UQ, CK)
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- ========================================================================================
-- 1. KHÓA NGOẠI (FOREIGN KEYS)
-- ========================================================================================

-- Users -> Roles
ALTER TABLE dbo.Users
    ADD CONSTRAINT FK_Users_Roles_RoleId FOREIGN KEY (RoleId) REFERENCES dbo.Roles(RoleId);

-- MovieGenres -> Movies, Genres
ALTER TABLE dbo.MovieGenres
    ADD CONSTRAINT FK_MovieGenres_Movies_MovieId FOREIGN KEY (MovieId) REFERENCES dbo.Movies(MovieId) ON DELETE CASCADE,
        CONSTRAINT FK_MovieGenres_Genres_GenreId FOREIGN KEY (GenreId) REFERENCES dbo.Genres(GenreId) ON DELETE CASCADE;

-- Seats -> Auditoriums, SeatTypes
ALTER TABLE dbo.Seats
    ADD CONSTRAINT FK_Seats_Auditoriums_AuditoriumId FOREIGN KEY (AuditoriumId) REFERENCES dbo.Auditoriums(AuditoriumId) ON DELETE CASCADE,
        CONSTRAINT FK_Seats_SeatTypes_SeatTypeId FOREIGN KEY (SeatTypeId) REFERENCES dbo.SeatTypes(SeatTypeId);

-- Showtimes -> Movies, Auditoriums
ALTER TABLE dbo.Showtimes
    ADD CONSTRAINT FK_Showtimes_Movies_MovieId FOREIGN KEY (MovieId) REFERENCES dbo.Movies(MovieId),
        CONSTRAINT FK_Showtimes_Auditoriums_AuditoriumId FOREIGN KEY (AuditoriumId) REFERENCES dbo.Auditoriums(AuditoriumId);

-- Orders -> Memberships, Users
ALTER TABLE dbo.Orders
    ADD CONSTRAINT FK_Orders_Memberships_MembershipId FOREIGN KEY (MembershipId) REFERENCES dbo.Memberships(MembershipId),
        CONSTRAINT FK_Orders_Users_StaffUserId FOREIGN KEY (StaffUserId) REFERENCES dbo.Users(UserId);

-- Tickets -> Orders, Showtimes, Seats
ALTER TABLE dbo.Tickets
    ADD CONSTRAINT FK_Tickets_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId) ON DELETE CASCADE,
        CONSTRAINT FK_Tickets_Showtimes_ShowtimeId FOREIGN KEY (ShowtimeId) REFERENCES dbo.Showtimes(ShowtimeId),
        CONSTRAINT FK_Tickets_Seats_SeatId FOREIGN KEY (SeatId) REFERENCES dbo.Seats(SeatId);

-- OrderConcessions -> Orders, Concessions
ALTER TABLE dbo.OrderConcessions
    ADD CONSTRAINT FK_OrderConcessions_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId) ON DELETE CASCADE,
        CONSTRAINT FK_OrderConcessions_Concessions_ConcessionId FOREIGN KEY (ConcessionId) REFERENCES dbo.Concessions(ConcessionId);

-- Shifts -> Users
ALTER TABLE dbo.Shifts
    ADD CONSTRAINT FK_Shifts_Users_UserId FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId);

-- RefundRequests -> Orders, Tickets, Users
ALTER TABLE dbo.RefundRequests
    ADD CONSTRAINT FK_RefundRequests_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId),
        CONSTRAINT FK_RefundRequests_Tickets_TicketId FOREIGN KEY (TicketId) REFERENCES dbo.Tickets(TicketId),
        CONSTRAINT FK_RefundRequests_Users_ProcessedBy FOREIGN KEY (ProcessedByUserId) REFERENCES dbo.Users(UserId);
GO

-- ========================================================================================
-- 2. RÀNG BUỘC DUY NHẤT (UNIQUE CONSTRAINTS)
-- ========================================================================================
ALTER TABLE dbo.Roles ADD CONSTRAINT UQ_Roles_RoleName UNIQUE NONCLUSTERED (RoleName);
ALTER TABLE dbo.Users ADD CONSTRAINT UQ_Users_Username UNIQUE NONCLUSTERED (Username);
ALTER TABLE dbo.Memberships ADD CONSTRAINT UQ_Memberships_CardNumber UNIQUE NONCLUSTERED (CardNumber);
ALTER TABLE dbo.Memberships ADD CONSTRAINT UQ_Memberships_PhoneNumber UNIQUE NONCLUSTERED (PhoneNumber);
ALTER TABLE dbo.Genres ADD CONSTRAINT UQ_Genres_GenreName UNIQUE NONCLUSTERED (GenreName);
ALTER TABLE dbo.Auditoriums ADD CONSTRAINT UQ_Auditoriums_Name UNIQUE NONCLUSTERED (Name);
ALTER TABLE dbo.SeatTypes ADD CONSTRAINT UQ_SeatTypes_TypeName UNIQUE NONCLUSTERED (TypeName);
ALTER TABLE dbo.Seats ADD CONSTRAINT UQ_Seats_Auditorium_SeatCode UNIQUE NONCLUSTERED (AuditoriumId, SeatCode);
ALTER TABLE dbo.Orders ADD CONSTRAINT UQ_Orders_OrderCode UNIQUE NONCLUSTERED (OrderCode);
ALTER TABLE dbo.Tickets ADD CONSTRAINT UQ_Tickets_Barcode UNIQUE NONCLUSTERED (Barcode);
GO

-- ========================================================================================
-- 3. RÀNG BUỘC KIỂM TRA (CHECK CONSTRAINTS)
-- ========================================================================================

-- SystemConfigs
ALTER TABLE dbo.SystemConfigs
    ADD CONSTRAINT CK_SystemConfigs_Key_NotEmpty CHECK (LEN(TRIM(ConfigKey)) > 0);

-- Roles
ALTER TABLE dbo.Roles
    ADD CONSTRAINT CK_Roles_RoleName_Valid CHECK (RoleName IN (N'Admin', N'Manager', N'Staff'));

-- Users
ALTER TABLE dbo.Users
    ADD CONSTRAINT CK_Users_Username_Format CHECK (LEN(Username) >= 3 AND Username NOT LIKE '%[^a-zA-Z0-9_]%'),
        CONSTRAINT CK_Users_Email CHECK (Email IS NULL OR (Email LIKE '%_@__%.__%')),
        CONSTRAINT CK_Users_PhoneNumber CHECK (PhoneNumber IS NULL OR (LEN(PhoneNumber) BETWEEN 10 AND 11 AND PhoneNumber NOT LIKE '%[^0-9]%'));

-- Memberships
ALTER TABLE dbo.Memberships
    ADD CONSTRAINT CK_Memberships_Points_NonNegative CHECK (Points >= 0),
        CONSTRAINT CK_Memberships_TotalSpent_NonNegative CHECK (TotalSpent >= 0),
        CONSTRAINT CK_Memberships_Tier CHECK (TierLevel IN (N'Standard', N'Silver', N'Gold', N'Platinum')),
        CONSTRAINT CK_Memberships_PhoneNumber CHECK (LEN(PhoneNumber) BETWEEN 10 AND 11 AND PhoneNumber NOT LIKE '%[^0-9]%'),
        CONSTRAINT CK_Memberships_Email CHECK (Email IS NULL OR (Email LIKE '%_@__%.__%'));

-- Genres
ALTER TABLE dbo.Genres
    ADD CONSTRAINT CK_Genres_Name_NotEmpty CHECK (LEN(TRIM(GenreName)) > 0);

-- Movies
ALTER TABLE dbo.Movies
    ADD CONSTRAINT CK_Movies_DurationMinutes_Positive CHECK (DurationMinutes > 0),
        CONSTRAINT CK_Movies_Dates_Valid CHECK (EndDate IS NULL OR EndDate >= ReleaseDate),
        CONSTRAINT CK_Movies_AgeRating CHECK (AgeRating IN (N'P', N'K', N'T13', N'T16', N'T18', N'C')),
        CONSTRAINT CK_Movies_Status CHECK (Status IN (N'ComingSoon', N'NowShowing', N'EndOfShowing')),
        CONSTRAINT CK_Movies_Title_NotEmpty CHECK (LEN(TRIM(Title)) > 0);

-- Auditoriums
ALTER TABLE dbo.Auditoriums
    ADD CONSTRAINT CK_Auditoriums_Rows_Cols_Positive CHECK (TotalRows > 0 AND TotalColumns > 0),
        CONSTRAINT CK_Auditoriums_ScreenType CHECK (ScreenType IN (N'2D Standard', N'3D Digital', N'IMAX Laser', N'4DX', N'ScreenX')),
        CONSTRAINT CK_Auditoriums_Status CHECK (Status IN (N'Active', N'Maintenance', N'Inactive'));

-- SeatTypes
ALTER TABLE dbo.SeatTypes
    ADD CONSTRAINT CK_SeatTypes_SurchargeAmount_NonNegative CHECK (SurchargeAmount >= 0),
        CONSTRAINT CK_SeatTypes_TypeName_Valid CHECK (TypeName IN (N'Standard', N'VIP', N'Sweetbox', N'Accessible'));

-- Seats
ALTER TABLE dbo.Seats
    ADD CONSTRAINT CK_Seats_Number_Positive CHECK (SeatNumber > 0);

-- Showtimes
ALTER TABLE dbo.Showtimes
    ADD CONSTRAINT CK_Showtimes_Times_Valid CHECK (EndTime > StartTime),
        CONSTRAINT CK_Showtimes_BasePrice_Positive CHECK (BasePrice > 0),
        CONSTRAINT CK_Showtimes_Status CHECK (Status IN (N'Scheduled', N'Showing', N'Finished', N'Cancelled'));

-- Concessions
ALTER TABLE dbo.Concessions
    ADD CONSTRAINT CK_Concessions_UnitPrice_Positive CHECK (UnitPrice >= 0),
        CONSTRAINT CK_Concessions_CostPrice_NonNegative CHECK (CostPrice >= 0),
        CONSTRAINT CK_Concessions_Stock_NonNegative CHECK (StockQuantity >= 0),
        CONSTRAINT CK_Concessions_Category CHECK (Category IN (N'Popcorn', N'Beverage', N'Combo', N'Snack')),
        CONSTRAINT CK_Concessions_Name_NotEmpty CHECK (LEN(TRIM(Name)) > 0);

-- Orders
ALTER TABLE dbo.Orders
    ADD CONSTRAINT CK_Orders_Amounts_Valid CHECK (SubTotal >= 0 AND DiscountAmount >= 0 AND FinalAmount >= 0),
        CONSTRAINT CK_Orders_FinalAmount_Math CHECK (FinalAmount <= SubTotal),
        CONSTRAINT CK_Orders_Points_Valid CHECK (PointsEarned >= 0 AND PointsRedeemed >= 0),
        CONSTRAINT CK_Orders_PaymentMethod CHECK (PaymentMethod IN ('CASH', 'VNPay', 'MoMo', 'VietQR', 'Card')),
        CONSTRAINT CK_Orders_PaymentStatus CHECK (PaymentStatus IN ('PENDING', 'PAID', 'REFUNDED', 'FAILED'));

-- Tickets
ALTER TABLE dbo.Tickets
    ADD CONSTRAINT CK_Tickets_Price_Positive CHECK (TicketPrice >= 0),
        CONSTRAINT CK_Tickets_Status CHECK (Status IN ('ISSUED', 'USED', 'REFUNDED', 'CANCELLED'));

-- OrderConcessions
ALTER TABLE dbo.OrderConcessions
    ADD CONSTRAINT CK_OrderConcessions_Quantity_Positive CHECK (Quantity > 0),
        CONSTRAINT CK_OrderConcessions_UnitPrice_NonNegative CHECK (UnitPrice >= 0),
        CONSTRAINT CK_OrderConcessions_TotalPrice_NonNegative CHECK (TotalPrice >= 0);

-- Shifts
ALTER TABLE dbo.Shifts
    ADD CONSTRAINT CK_Shifts_Status CHECK (Status IN ('OPEN', 'CLOSED')),
        CONSTRAINT CK_Shifts_Times CHECK (EndTime IS NULL OR EndTime >= StartTime),
        CONSTRAINT CK_Shifts_InitialCash CHECK (InitialCash >= 0),
        CONSTRAINT CK_Shifts_FinalCash CHECK (FinalCash IS NULL OR FinalCash >= 0),
        CONSTRAINT CK_Shifts_TotalSales CHECK (TotalSales >= 0);

-- RefundRequests
ALTER TABLE dbo.RefundRequests
    ADD CONSTRAINT CK_RefundRequests_Status CHECK (Status IN ('PENDING', 'APPROVED', 'REJECTED')),
        CONSTRAINT CK_RefundRequests_Amount CHECK (RefundAmount > 0);
GO

PRINT N'>> [03_constraints.sql] Tạo thành công toàn bộ Khóa ngoại, Ràng buộc duy nhất & Check Constraints!';
GO
