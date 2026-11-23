/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 02: TẠO CẤU TRÚC 18 BẢNG DỮ LIỆU (CREATE TABLES)
   Chuẩn hóa 3NF - Tương thích EF Core 10 / .NET 10
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- XÓA BẢNG CŨ THEO THỨ TỰ RÀNG BUỘC (NẾU ĐÃ TỒN TẠI)
IF OBJECT_ID(N'dbo.AuditLogs', N'U') IS NOT NULL DROP TABLE dbo.AuditLogs;
IF OBJECT_ID(N'dbo.RefundRequests', N'U') IS NOT NULL DROP TABLE dbo.RefundRequests;
IF OBJECT_ID(N'dbo.OrderConcessions', N'U') IS NOT NULL DROP TABLE dbo.OrderConcessions;
IF OBJECT_ID(N'dbo.Tickets', N'U') IS NOT NULL DROP TABLE dbo.Tickets;
IF OBJECT_ID(N'dbo.Orders', N'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID(N'dbo.Shifts', N'U') IS NOT NULL DROP TABLE dbo.Shifts;
IF OBJECT_ID(N'dbo.Concessions', N'U') IS NOT NULL DROP TABLE dbo.Concessions;
IF OBJECT_ID(N'dbo.Showtimes', N'U') IS NOT NULL DROP TABLE dbo.Showtimes;
IF OBJECT_ID(N'dbo.Seats', N'U') IS NOT NULL DROP TABLE dbo.Seats;
IF OBJECT_ID(N'dbo.SeatTypes', N'U') IS NOT NULL DROP TABLE dbo.SeatTypes;
IF OBJECT_ID(N'dbo.Auditoriums', N'U') IS NOT NULL DROP TABLE dbo.Auditoriums;
IF OBJECT_ID(N'dbo.MovieGenres', N'U') IS NOT NULL DROP TABLE dbo.MovieGenres;
IF OBJECT_ID(N'dbo.Movies', N'U') IS NOT NULL DROP TABLE dbo.Movies;
IF OBJECT_ID(N'dbo.Genres', N'U') IS NOT NULL DROP TABLE dbo.Genres;
IF OBJECT_ID(N'dbo.Memberships', N'U') IS NOT NULL DROP TABLE dbo.Memberships;
IF OBJECT_ID(N'dbo.Users', N'U') IS NOT NULL DROP TABLE dbo.Users;
IF OBJECT_ID(N'dbo.Roles', N'U') IS NOT NULL DROP TABLE dbo.Roles;
IF OBJECT_ID(N'dbo.SystemConfigs', N'U') IS NOT NULL DROP TABLE dbo.SystemConfigs;
GO

-- 1. BẢNG CẤU HÌNH HỆ THỐNG
CREATE TABLE dbo.SystemConfigs (
    ConfigKey NVARCHAR(50) NOT NULL,
    ConfigValue NVARCHAR(500) NOT NULL,
    Description NVARCHAR(255) NULL,
    UpdatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_SystemConfigs_UpdatedAt DEFAULT GETDATE(),
    CONSTRAINT PK_SystemConfigs PRIMARY KEY CLUSTERED (ConfigKey)
);
GO

-- 2. BẢNG VAI TRÒ (ROLES)
CREATE TABLE dbo.Roles (
    RoleId INT IDENTITY(1,1) NOT NULL,
    RoleName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Roles_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (RoleId)
);
GO

-- 3. BẢNG TÀI KHOẢN NGƯỜI DÙNG (USERS)
CREATE TABLE dbo.Users (
    UserId INT IDENTITY(1,1) NOT NULL,
    Username VARCHAR(50) NOT NULL,
    PasswordHash VARCHAR(256) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NULL,
    PhoneNumber VARCHAR(20) NULL,
    RoleId INT NOT NULL,
    IsActive BIT NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT 1,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT GETDATE(),
    CreatedBy NVARCHAR(50) NULL,
    UpdatedAt DATETIME2(0) NULL,
    UpdatedBy NVARCHAR(50) NULL,
    IsDeleted BIT NOT NULL CONSTRAINT DF_Users_IsDeleted DEFAULT 0,
    CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (UserId)
);
GO

-- 4. BẢNG KHÁCH HÀNG THÀNH VIÊN (MEMBERSHIPS)
CREATE TABLE dbo.Memberships (
    MembershipId INT IDENTITY(1,1) NOT NULL,
    CardNumber VARCHAR(30) NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    Email VARCHAR(100) NULL,
    Birthday DATE NULL,
    Points INT NOT NULL CONSTRAINT DF_Memberships_Points DEFAULT 0,
    TierLevel NVARCHAR(30) NOT NULL CONSTRAINT DF_Memberships_Tier DEFAULT N'Standard',
    TotalSpent DECIMAL(18,2) NOT NULL CONSTRAINT DF_Memberships_TotalSpent DEFAULT 0,
    RegisteredDate DATETIME2(0) NOT NULL CONSTRAINT DF_Memberships_RegDate DEFAULT GETDATE(),
    IsActive BIT NOT NULL CONSTRAINT DF_Memberships_IsActive DEFAULT 1,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Memberships_CreatedAt DEFAULT GETDATE(),
    UpdatedAt DATETIME2(0) NULL,
    IsDeleted BIT NOT NULL CONSTRAINT DF_Memberships_IsDeleted DEFAULT 0,
    CONSTRAINT PK_Memberships PRIMARY KEY CLUSTERED (MembershipId)
);
GO

-- 5. BẢNG THỂ LOẠI PHIM (GENRES)
CREATE TABLE dbo.Genres (
    GenreId INT IDENTITY(1,1) NOT NULL,
    GenreName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
    CONSTRAINT PK_Genres PRIMARY KEY CLUSTERED (GenreId)
);
GO

-- 6. BẢNG PHIM (MOVIES)
CREATE TABLE dbo.Movies (
    MovieId INT IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    EnglishTitle NVARCHAR(200) NULL,
    Director NVARCHAR(150) NULL,
    Cast NVARCHAR(500) NULL,
    DurationMinutes INT NOT NULL,
    ReleaseDate DATE NOT NULL,
    EndDate DATE NULL,
    AgeRating NVARCHAR(10) NOT NULL CONSTRAINT DF_Movies_AgeRating DEFAULT N'P',
    Language NVARCHAR(50) NOT NULL CONSTRAINT DF_Movies_Language DEFAULT N'Tiếng Việt',
    Subtitle NVARCHAR(50) NULL,
    PosterUrl NVARCHAR(500) NULL,
    TrailerUrl NVARCHAR(500) NULL,
    Description NVARCHAR(MAX) NULL,
    Status NVARCHAR(30) NOT NULL CONSTRAINT DF_Movies_Status DEFAULT N'NowShowing',
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Movies_CreatedAt DEFAULT GETDATE(),
    CreatedBy NVARCHAR(50) NULL,
    UpdatedAt DATETIME2(0) NULL,
    UpdatedBy NVARCHAR(50) NULL,
    IsDeleted BIT NOT NULL CONSTRAINT DF_Movies_IsDeleted DEFAULT 0,
    CONSTRAINT PK_Movies PRIMARY KEY CLUSTERED (MovieId)
);
GO

-- 7. BẢNG LIÊN KẾT PHIM - THỂ LOẠI (MOVIEGENRES)
CREATE TABLE dbo.MovieGenres (
    MovieId INT NOT NULL,
    GenreId INT NOT NULL,
    CONSTRAINT PK_MovieGenres PRIMARY KEY CLUSTERED (MovieId, GenreId)
);
GO

-- 8. BẢNG PHÒNG CHIẾU (AUDITORIUMS)
CREATE TABLE dbo.Auditoriums (
    AuditoriumId INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    ScreenType NVARCHAR(50) NOT NULL CONSTRAINT DF_Auditoriums_ScreenType DEFAULT N'2D Standard',
    TotalSeats INT NOT NULL CONSTRAINT DF_Auditoriums_TotalSeats DEFAULT 0,
    TotalRows INT NOT NULL,
    TotalColumns INT NOT NULL,
    Status NVARCHAR(30) NOT NULL CONSTRAINT DF_Auditoriums_Status DEFAULT N'Active',
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Auditoriums_CreatedAt DEFAULT GETDATE(),
    IsDeleted BIT NOT NULL CONSTRAINT DF_Auditoriums_IsDeleted DEFAULT 0,
    CONSTRAINT PK_Auditoriums PRIMARY KEY CLUSTERED (AuditoriumId)
);
GO

-- 9. BẢNG LOẠI GHẾ (SEATTYPES)
CREATE TABLE dbo.SeatTypes (
    SeatTypeId INT IDENTITY(1,1) NOT NULL,
    TypeName NVARCHAR(50) NOT NULL,
    ColorCode VARCHAR(20) NOT NULL CONSTRAINT DF_SeatTypes_ColorCode DEFAULT '#64748B',
    SurchargeAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_SeatTypes_SurchargeAmount DEFAULT 0,
    Description NVARCHAR(255) NULL,
    CONSTRAINT PK_SeatTypes PRIMARY KEY CLUSTERED (SeatTypeId)
);
GO

-- 10. BẢNG GHẾ THEO PHÒNG (SEATS)
CREATE TABLE dbo.Seats (
    SeatId INT IDENTITY(1,1) NOT NULL,
    AuditoriumId INT NOT NULL,
    SeatRow VARCHAR(5) NOT NULL,
    SeatNumber INT NOT NULL,
    SeatCode VARCHAR(10) NOT NULL,
    SeatTypeId INT NOT NULL,
    IsActive BIT NOT NULL CONSTRAINT DF_Seats_IsActive DEFAULT 1,
    CONSTRAINT PK_Seats PRIMARY KEY CLUSTERED (SeatId)
);
GO

-- 11. BẢNG SUẤT CHIẾU (SHOWTIMES)
CREATE TABLE dbo.Showtimes (
    ShowtimeId INT IDENTITY(1,1) NOT NULL,
    MovieId INT NOT NULL,
    AuditoriumId INT NOT NULL,
    StartTime DATETIME2(0) NOT NULL,
    EndTime DATETIME2(0) NOT NULL,
    BasePrice DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(30) NOT NULL CONSTRAINT DF_Showtimes_Status DEFAULT N'Scheduled',
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Showtimes_CreatedAt DEFAULT GETDATE(),
    CreatedBy NVARCHAR(50) NULL,
    UpdatedAt DATETIME2(0) NULL,
    UpdatedBy NVARCHAR(50) NULL,
    IsDeleted BIT NOT NULL CONSTRAINT DF_Showtimes_IsDeleted DEFAULT 0,
    CONSTRAINT PK_Showtimes PRIMARY KEY CLUSTERED (ShowtimeId)
);
GO

-- 12. BẢNG BẮP NƯỚC & COMBO (CONCESSIONS)
CREATE TABLE dbo.Concessions (
    ConcessionId INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(150) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Unit NVARCHAR(30) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    CostPrice DECIMAL(18,2) NOT NULL CONSTRAINT DF_Concessions_CostPrice DEFAULT 0,
    StockQuantity INT NOT NULL CONSTRAINT DF_Concessions_Stock DEFAULT 0,
    ImageUrl NVARCHAR(500) NULL,
    IsActive BIT NOT NULL CONSTRAINT DF_Concessions_IsActive DEFAULT 1,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Concessions_CreatedAt DEFAULT GETDATE(),
    UpdatedAt DATETIME2(0) NULL,
    IsDeleted BIT NOT NULL CONSTRAINT DF_Concessions_IsDeleted DEFAULT 0,
    CONSTRAINT PK_Concessions PRIMARY KEY CLUSTERED (ConcessionId)
);
GO

-- 13. BẢNG ĐƠN HÀNG (ORDERS)
CREATE TABLE dbo.Orders (
    OrderId INT IDENTITY(1,1) NOT NULL,
    OrderCode VARCHAR(30) NOT NULL,
    MembershipId INT NULL,
    StaffUserId INT NULL,
    OrderDate DATETIME2(0) NOT NULL CONSTRAINT DF_Orders_OrderDate DEFAULT GETDATE(),
    SubTotal DECIMAL(18,2) NOT NULL,
    DiscountAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_Orders_Discount DEFAULT 0,
    FinalAmount DECIMAL(18,2) NOT NULL,
    PaymentMethod VARCHAR(30) NOT NULL CONSTRAINT DF_Orders_PaymentMethod DEFAULT 'CASH',
    PaymentStatus VARCHAR(30) NOT NULL CONSTRAINT DF_Orders_PaymentStatus DEFAULT 'PAID',
    PointsEarned INT NOT NULL CONSTRAINT DF_Orders_PointsEarned DEFAULT 0,
    PointsRedeemed INT NOT NULL CONSTRAINT DF_Orders_PointsRedeemed DEFAULT 0,
    Notes NVARCHAR(255) NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Orders_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT PK_Orders PRIMARY KEY CLUSTERED (OrderId)
);
GO

-- 14. BẢNG VÉ XEM PHIM (TICKETS)
CREATE TABLE dbo.Tickets (
    TicketId INT IDENTITY(1,1) NOT NULL,
    OrderId INT NOT NULL,
    ShowtimeId INT NOT NULL,
    SeatId INT NOT NULL,
    TicketPrice DECIMAL(18,2) NOT NULL,
    Barcode VARCHAR(50) NOT NULL,
    Status VARCHAR(30) NOT NULL CONSTRAINT DF_Tickets_Status DEFAULT 'ISSUED',
    CheckinTime DATETIME2(0) NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Tickets_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT PK_Tickets PRIMARY KEY CLUSTERED (TicketId)
);
GO

-- 15. BẢNG CHI TIẾT BẮP NƯỚC ĐƠN HÀNG (ORDERCONCESSIONS)
CREATE TABLE dbo.OrderConcessions (
    OrderConcessionId INT IDENTITY(1,1) NOT NULL,
    OrderId INT NOT NULL,
    ConcessionId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_OrderConcessions PRIMARY KEY CLUSTERED (OrderConcessionId)
);
GO

-- 16. BẢNG CA LÀM VIỆC (SHIFTS)
CREATE TABLE dbo.Shifts (
    ShiftId INT IDENTITY(1,1) NOT NULL,
    UserId INT NOT NULL,
    ShiftName NVARCHAR(50) NOT NULL,
    StartTime DATETIME2(0) NOT NULL,
    EndTime DATETIME2(0) NULL,
    InitialCash DECIMAL(18,2) NOT NULL CONSTRAINT DF_Shifts_InitialCash DEFAULT 0,
    FinalCash DECIMAL(18,2) NULL,
    TotalSales DECIMAL(18,2) NOT NULL CONSTRAINT DF_Shifts_TotalSales DEFAULT 0,
    CashDifference DECIMAL(18,2) NULL,
    Status VARCHAR(30) NOT NULL CONSTRAINT DF_Shifts_Status DEFAULT 'OPEN',
    Notes NVARCHAR(255) NULL,
    CONSTRAINT PK_Shifts PRIMARY KEY CLUSTERED (ShiftId)
);
GO

-- 17. BẢNG YÊU CẦU HOÀN VÉ (REFUNDREQUESTS)
CREATE TABLE dbo.RefundRequests (
    RefundId INT IDENTITY(1,1) NOT NULL,
    OrderId INT NOT NULL,
    TicketId INT NOT NULL,
    RefundReason NVARCHAR(255) NOT NULL,
    RefundAmount DECIMAL(18,2) NOT NULL,
    RequestedAt DATETIME2(0) NOT NULL CONSTRAINT DF_RefundRequests_ReqAt DEFAULT GETDATE(),
    ProcessedByUserId INT NULL,
    Status VARCHAR(30) NOT NULL CONSTRAINT DF_RefundRequests_Status DEFAULT 'APPROVED',
    Notes NVARCHAR(255) NULL,
    CONSTRAINT PK_RefundRequests PRIMARY KEY CLUSTERED (RefundId)
);
GO

-- 18. BẢNG NHẬT KÝ HỆ THỐNG (AUDITLOGS)
CREATE TABLE dbo.AuditLogs (
    LogId BIGINT IDENTITY(1,1) NOT NULL,
    UserId INT NULL,
    Action NVARCHAR(50) NOT NULL,
    TableName NVARCHAR(50) NOT NULL,
    RecordId NVARCHAR(50) NULL,
    OldValues NVARCHAR(MAX) NULL,
    NewValues NVARCHAR(MAX) NULL,
    Timestamp DATETIME2(0) NOT NULL CONSTRAINT DF_AuditLogs_Timestamp DEFAULT GETDATE(),
    IpAddress VARCHAR(45) NULL,
    CONSTRAINT PK_AuditLogs PRIMARY KEY CLUSTERED (LogId)
);
GO

PRINT N'>> [02_create_tables.sql] Tạo thành công 18 bảng dữ liệu!';
GO
