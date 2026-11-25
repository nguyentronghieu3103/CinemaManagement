/*
    STORYLINE | 02 - Tạo 22 bảng và ràng buộc
    Chạy sau 01_Create_CinemaManagement.sql, trên cùng SQL Server instance.
    Dành cho database trống. Toàn bộ bảng và chỉ mục được tạo trong một transaction.
    Tiền lưu theo VND, không có phần lẻ. Thời điểm có hậu tố Utc lưu theo UTC.
    Thời gian mở cửa, mốc phụ thu trong ngày và ngày sinh dùng giờ/ngày địa phương.
    Mỗi đơn vé thuộc một suất. POS dùng tiền mặt hoặc VietQR, web dùng VietQR.
    Thành viên khởi tạo ở hạng Bạc. Điểm nâng hạng và điểm tiêu dùng có số dư
    và biến động riêng. Tỷ lệ tích, ngưỡng nâng hạng và giá đổi vé thuộc backend.
    File chỉ tạo schema. Cấu hình rạp, bảng giá, tài khoản và quyền được tạo riêng.
    Khi có EF Core migration, chọn một cách khởi tạo schema cho mỗi database.
*/
USE [CinemaManagement];
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET QUOTED_IDENTIFIER ON;
SET NUMERIC_ROUNDABORT OFF;

IF DB_NAME() <> N'CinemaManagement'
    THROW 51000, N'Hãy chạy file 01 để tạo database CinemaManagement trước.', 1;

IF EXISTS (SELECT 1 FROM sys.tables WHERE is_ms_shipped = 0)
    THROW 51001, N'Database đã có bảng. Hãy dùng database trống hoặc cập nhật bằng migration.', 1;

BEGIN TRY
    BEGIN TRANSACTION;

    /* 01. Một tài khoản thuộc một vai trò. Email và điện thoại đăng nhập là tùy chọn. */
    CREATE TABLE dbo.UserAccounts
    (
        UserAccountId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_UserAccounts PRIMARY KEY,
        LoginName nvarchar(100) NOT NULL CONSTRAINT UQ_UserAccounts_LoginName UNIQUE,
        DisplayName nvarchar(120) NOT NULL,
        Email nvarchar(254) NULL,
        Phone varchar(20) NULL,
        EmailVerifiedAtUtc datetime2(0) NULL,
        EmployeeCode varchar(24) NULL,
        PasswordHash nvarchar(512) NOT NULL,
        RoleCode varchar(16) NOT NULL,
        IsActive bit NOT NULL CONSTRAINT DF_UserAccounts_IsActive DEFAULT (1),
        MustChangePassword bit NOT NULL CONSTRAINT DF_UserAccounts_MustChangePassword DEFAULT (0),
        CreatedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_UserAccounts_Created DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT CK_UserAccounts_Role CHECK (RoleCode IN ('Admin','Manager','Employee','Customer')),
        CONSTRAINT CK_UserAccounts_Required CHECK
        (
            LEN(LoginName) > 0 AND LEN(DisplayName) > 0 AND LEN(PasswordHash) > 0
            AND (Email IS NULL OR LEN(Email) > 0)
            AND (Phone IS NULL OR LEN(Phone) > 0)
            AND (EmailVerifiedAtUtc IS NULL OR Email IS NOT NULL)
            AND (EmployeeCode IS NULL OR (RoleCode <> 'Customer' AND LEN(EmployeeCode) > 0))
        )
    );

    /* 02. Thành viên mới là Silver. Có thể liên kết tài khoản web sau khi đăng ký tại quầy. */
    CREATE TABLE dbo.Members
    (
        MemberId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Members PRIMARY KEY,
        MemberCode varchar(24) NOT NULL CONSTRAINT UQ_Members_MemberCode UNIQUE,
        UserAccountId int NULL,
        FullName nvarchar(120) NOT NULL,
        Phone varchar(20) NOT NULL CONSTRAINT UQ_Members_Phone UNIQUE,
        Email nvarchar(254) NULL,
        BirthDate date NULL,
        GenderCode varchar(12) NULL,
        TermsAcceptedAtUtc datetime2(0) NOT NULL,
        TermsVersion varchar(32) NOT NULL,
        TierCode varchar(12) NOT NULL CONSTRAINT DF_Members_Tier DEFAULT ('Silver'),
        TierPoints bigint NOT NULL CONSTRAINT DF_Members_TierPoints DEFAULT (0),
        SpendablePoints bigint NOT NULL CONSTRAINT DF_Members_SpendablePoints DEFAULT (0),
        IsActive bit NOT NULL CONSTRAINT DF_Members_IsActive DEFAULT (1),
        JoinedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_Members_Joined DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_Members_UserAccounts FOREIGN KEY (UserAccountId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_Members_Tier CHECK (TierCode IN ('Silver','Gold','Diamond')),
        CONSTRAINT CK_Members_Points CHECK (TierPoints >= 0 AND SpendablePoints >= 0),
        CONSTRAINT CK_Members_Gender CHECK (GenderCode IS NULL OR GenderCode IN ('Male','Female','Other')),
        CONSTRAINT CK_Members_Terms CHECK (LEN(TermsVersion) > 0 AND TermsAcceptedAtUtc <= JoinedAtUtc),
        CONSTRAINT CK_Members_Contact CHECK
        (
            LEN(MemberCode) > 0 AND LEN(FullName) > 0 AND LEN(Phone) > 0
            AND (Email IS NULL OR LEN(Email) > 0)
        )
    );

    /* 03. Mỗi phim lưu thông tin của một hợp đồng phát hành hiện tại. */
    CREATE TABLE dbo.Movies
    (
        MovieId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Movies PRIMARY KEY,
        Title nvarchar(200) NOT NULL,
        Genre nvarchar(80) NOT NULL,
        Synopsis nvarchar(max) NULL,
        CastText nvarchar(600) NULL,
        DurationMinutes smallint NOT NULL,
        AgeRating varchar(4) NOT NULL,
        PosterUrl nvarchar(1000) NULL,
        TrailerUrl nvarchar(1000) NULL,
        ReleaseDate date NULL,
        DistributorName nvarchar(160) NULL,
        ContractNumber nvarchar(80) NULL,
        LicenseStartDate date NULL,
        LicenseEndDate date NULL,
        LicenseStatus varchar(16) NOT NULL CONSTRAINT DF_Movies_LicenseStatus DEFAULT ('Pending'),
        ReleaseStatus varchar(16) NOT NULL CONSTRAINT DF_Movies_ReleaseStatus DEFAULT ('ComingSoon'),
        ApprovedByUserId int NULL,
        ApprovedAtUtc datetime2(0) NULL,
        CONSTRAINT FK_Movies_ApprovedBy FOREIGN KEY (ApprovedByUserId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_Movies_Details CHECK
        (
            LEN(Title) > 0 AND LEN(Genre) > 0 AND DurationMinutes > 0
            AND AgeRating IN ('P','K','C13','C16','C18')
        ),
        CONSTRAINT CK_Movies_Status CHECK
        (
            LicenseStatus IN ('Pending','Approved','Suspended','Withdrawn')
            AND ReleaseStatus IN ('ComingSoon','NowShowing','Stopped')
            AND (LicenseStatus <> 'Approved' OR ApprovedByUserId IS NOT NULL)
            AND ((ApprovedByUserId IS NULL AND ApprovedAtUtc IS NULL)
                OR (ApprovedByUserId IS NOT NULL AND ApprovedAtUtc IS NOT NULL))
        ),
        CONSTRAINT CK_Movies_LicenseDates CHECK
        (
            LicenseEndDate IS NULL OR (LicenseStartDate IS NOT NULL AND LicenseEndDate >= LicenseStartDate)
        )
    );

    /* 04. Phòng 3D hỗ trợ cả suất 2D. Kiểm tra định dạng phù hợp khi xếp suất. */
    CREATE TABLE dbo.Auditoriums
    (
        AuditoriumId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Auditoriums PRIMARY KEY,
        AuditoriumCode varchar(24) NOT NULL CONSTRAINT UQ_Auditoriums_Code UNIQUE,
        AuditoriumName nvarchar(100) NOT NULL,
        Supports3D bit NOT NULL CONSTRAINT DF_Auditoriums_Supports3D DEFAULT (0),
        [RowCount] smallint NOT NULL,
        ColumnCount smallint NOT NULL,
        IsActive bit NOT NULL CONSTRAINT DF_Auditoriums_IsActive DEFAULT (1),
        CONSTRAINT CK_Auditoriums_Layout CHECK
        (
            LEN(AuditoriumCode) > 0 AND LEN(AuditoriumName) > 0 AND [RowCount] > 0 AND ColumnCount > 0
        )
    );

    /* 05. Một ghế đôi là một vị trí đặt vé, chiếm hai ô trên sơ đồ. */
    CREATE TABLE dbo.Seats
    (
        SeatId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Seats PRIMARY KEY,
        AuditoriumId int NOT NULL,
        SeatCode varchar(16) NOT NULL,
        RowNumber smallint NOT NULL,
        ColumnNumber smallint NOT NULL,
        SeatType varchar(12) NOT NULL,
        ColumnSpan AS CONVERT(tinyint, CASE WHEN SeatType = 'Sweetbox' THEN 2 ELSE 1 END),
        IsActive bit NOT NULL CONSTRAINT DF_Seats_IsActive DEFAULT (1),
        CONSTRAINT FK_Seats_Auditoriums FOREIGN KEY (AuditoriumId) REFERENCES dbo.Auditoriums(AuditoriumId),
        CONSTRAINT UQ_Seats_Code UNIQUE (AuditoriumId, SeatCode),
        CONSTRAINT UQ_Seats_Position UNIQUE (AuditoriumId, RowNumber, ColumnNumber),
        CONSTRAINT UQ_Seats_Room_Seat UNIQUE (AuditoriumId, SeatId),
        CONSTRAINT CK_Seats_Layout CHECK
        (
            LEN(SeatCode) > 0 AND RowNumber > 0 AND ColumnNumber > 0
            AND SeatType IN ('Standard','VIP','Sweetbox')
        )
    );

    /* 06. Thời gian phòng bận bao gồm cả khoảng chuẩn bị sau phim. */
    CREATE TABLE dbo.Showtimes
    (
        ShowtimeId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Showtimes PRIMARY KEY,
        MovieId int NOT NULL,
        AuditoriumId int NOT NULL,
        FormatCode varchar(4) NOT NULL,
        StartsAtUtc datetime2(0) NOT NULL,
        EndsAtUtc datetime2(0) NOT NULL,
        RoomBusyUntilUtc datetime2(0) NOT NULL,
        SalesStatus varchar(16) NOT NULL CONSTRAINT DF_Showtimes_SalesStatus DEFAULT ('Scheduled'),
        CreatedByUserId int NOT NULL,
        CONSTRAINT FK_Showtimes_Movies FOREIGN KEY (MovieId) REFERENCES dbo.Movies(MovieId),
        CONSTRAINT FK_Showtimes_Auditoriums FOREIGN KEY (AuditoriumId) REFERENCES dbo.Auditoriums(AuditoriumId),
        CONSTRAINT FK_Showtimes_CreatedBy FOREIGN KEY (CreatedByUserId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT UQ_Showtimes_Room_Showtime UNIQUE (AuditoriumId, ShowtimeId),
        CONSTRAINT CK_Showtimes_Time CHECK (StartsAtUtc < EndsAtUtc AND EndsAtUtc <= RoomBusyUntilUtc),
        CONSTRAINT CK_Showtimes_Format CHECK (FormatCode IN ('2D','3D')),
        CONSTRAINT CK_Showtimes_Status CHECK (SalesStatus IN ('Scheduled','OnSale','SalesClosed','Cancelled'))
    );

    /* 07. Giá gốc và phụ thu, dùng chung hoặc dành riêng cho một suất. */
    CREATE TABLE dbo.TicketPriceRules
    (
        TicketPriceRuleId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_TicketPriceRules PRIMARY KEY,
        ShowtimeId int NULL,
        RuleName nvarchar(120) NOT NULL,
        RuleType varchar(10) NOT NULL,
        SeatType varchar(12) NULL,
        FormatCode varchar(4) NULL,
        DayType varchar(12) NOT NULL CONSTRAINT DF_TicketPriceRules_DayType DEFAULT ('Any'),
        EffectiveFromDate date NULL,
        EffectiveToDate date NULL,
        AppliesFromLocal time(0) NULL,
        AppliesToLocal time(0) NULL,
        Amount decimal(19,0) NOT NULL,
        Priority smallint NOT NULL CONSTRAINT DF_TicketPriceRules_Priority DEFAULT (0),
        IsActive bit NOT NULL CONSTRAINT DF_TicketPriceRules_IsActive DEFAULT (1),
        CONSTRAINT FK_TicketPriceRules_Showtimes FOREIGN KEY (ShowtimeId) REFERENCES dbo.Showtimes(ShowtimeId),
        CONSTRAINT CK_TicketPriceRules_Values CHECK
        (
            LEN(RuleName) > 0 AND RuleType IN ('Base','Surcharge')
            AND (SeatType IS NULL OR SeatType IN ('Standard','VIP','Sweetbox'))
            AND (FormatCode IS NULL OR FormatCode IN ('2D','3D'))
            AND DayType IN ('Any','Weekday','Weekend','Holiday')
            AND Amount >= 0 AND Priority >= 0
            AND (DayType <> 'Holiday' OR (EffectiveFromDate IS NOT NULL AND EffectiveToDate IS NOT NULL))
        ),
        CONSTRAINT CK_TicketPriceRules_Period CHECK
        (
            (EffectiveFromDate IS NULL OR EffectiveToDate IS NULL OR EffectiveFromDate <= EffectiveToDate)
            AND ((AppliesFromLocal IS NULL AND AppliesToLocal IS NULL)
                OR (AppliesFromLocal IS NOT NULL AND AppliesToLocal IS NOT NULL
                    AND AppliesFromLocal <> AppliesToLocal))
        )
    );

    /* 08. Món lẻ và combo cùng một danh mục, mỗi mặt hàng theo dõi tồn riêng. */
    CREATE TABLE dbo.Products
    (
        ProductId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Products PRIMARY KEY,
        ProductCode varchar(24) NOT NULL CONSTRAINT UQ_Products_Code UNIQUE,
        ProductName nvarchar(160) NOT NULL,
        CategoryCode varchar(12) NOT NULL,
        Description nvarchar(400) NULL,
        ImageUrl nvarchar(1000) NULL,
        ListPrice decimal(19,0) NOT NULL,
        SalePrice decimal(19,0) NULL,
        IsActive bit NOT NULL CONSTRAINT DF_Products_IsActive DEFAULT (1),
        IsAvailableAtPos bit NOT NULL CONSTRAINT DF_Products_IsAvailableAtPos DEFAULT (1),
        IsAvailableOnline bit NOT NULL CONSTRAINT DF_Products_IsAvailableOnline DEFAULT (1),
        CONSTRAINT CK_Products_Details CHECK
        (
            LEN(ProductCode) > 0 AND LEN(ProductName) > 0
            AND CategoryCode IN ('Combo','Popcorn','Drink','Snack')
            AND ListPrice >= 0 AND (SalePrice IS NULL OR SalePrice BETWEEN 0 AND ListPrice)
        )
    );

    /* 09. Kết ca lưu số đã đối soát để báo cáo về sau đọc đúng số đã bàn giao. */
    CREATE TABLE dbo.Shifts
    (
        ShiftId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Shifts PRIMARY KEY,
        ShiftCode varchar(32) NOT NULL CONSTRAINT UQ_Shifts_Code UNIQUE,
        EmployeeUserId int NOT NULL,
        TerminalCode varchar(24) NOT NULL,
        WorkDateLocal date NOT NULL,
        ShiftLabel nvarchar(50) NOT NULL,
        ScheduledStartLocal time(0) NULL,
        ScheduledEndLocal time(0) NULL,
        OpenedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_Shifts_Opened DEFAULT (SYSUTCDATETIME()),
        OpeningCash decimal(19,0) NOT NULL,
        OpeningNote nvarchar(400) NULL,
        Status varchar(16) NOT NULL CONSTRAINT DF_Shifts_Status DEFAULT ('Open'),
        ClosedAtUtc datetime2(0) NULL,
        CashReceived decimal(19,0) NULL,
        CashRefunded decimal(19,0) NULL,
        CashCounted decimal(19,0) NULL,
        ExpectedCash AS (OpeningCash + CashReceived - CashRefunded),
        CashDifference AS (CashCounted - (OpeningCash + CashReceived - CashRefunded)),
        ClosingNote nvarchar(500) NULL,
        ReviewedByUserId int NULL,
        ReviewedAtUtc datetime2(0) NULL,
        ReviewNote nvarchar(500) NULL,
        CONSTRAINT UQ_Shifts_Employee_Shift UNIQUE (EmployeeUserId, ShiftId),
        CONSTRAINT FK_Shifts_Employee FOREIGN KEY (EmployeeUserId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT FK_Shifts_ReviewedBy FOREIGN KEY (ReviewedByUserId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_Shifts_Values CHECK
        (
            LEN(ShiftCode) > 0 AND LEN(TerminalCode) > 0 AND LEN(ShiftLabel) > 0
            AND OpeningCash >= 0
            AND ((ScheduledStartLocal IS NULL AND ScheduledEndLocal IS NULL)
                OR (ScheduledStartLocal IS NOT NULL AND ScheduledEndLocal IS NOT NULL
                    AND ScheduledStartLocal <> ScheduledEndLocal))
        ),
        CONSTRAINT CK_Shifts_Close CHECK
        (
            (Status = 'Open' AND ClosedAtUtc IS NULL
                AND CashReceived IS NULL AND CashRefunded IS NULL AND CashCounted IS NULL)
            OR (Status IN ('Closed','Reconciled')
                AND ClosedAtUtc IS NOT NULL AND ClosedAtUtc >= OpenedAtUtc
                AND CashReceived IS NOT NULL AND CashReceived >= 0
                AND CashRefunded IS NOT NULL AND CashRefunded >= 0
                AND CashCounted IS NOT NULL AND CashCounted >= 0
                AND (CashCounted = OpeningCash + CashReceived - CashRefunded
                    OR (ClosingNote IS NOT NULL AND LEN(ClosingNote) > 0)))
        ),
        CONSTRAINT CK_Shifts_Review CHECK
        (
            (Status IN ('Open','Closed') AND ReviewedByUserId IS NULL AND ReviewedAtUtc IS NULL)
            OR (Status = 'Reconciled' AND ReviewedByUserId IS NOT NULL
                AND ReviewedAtUtc IS NOT NULL AND ReviewedAtUtc >= ClosedAtUtc)
        )
    );

    /* 10. Mỗi mệnh giá có tối đa một dòng kiểm đếm trong mỗi ca. */
    CREATE TABLE dbo.ShiftCashCounts
    (
        ShiftId int NOT NULL,
        Denomination int NOT NULL,
        Quantity int NOT NULL,
        LineAmount AS (CONVERT(bigint, Denomination) * Quantity),
        CONSTRAINT PK_ShiftCashCounts PRIMARY KEY (ShiftId, Denomination),
        CONSTRAINT FK_ShiftCashCounts_Shifts FOREIGN KEY (ShiftId) REFERENCES dbo.Shifts(ShiftId),
        CONSTRAINT CK_ShiftCashCounts_Values CHECK
        (
            Denomination IN (1000,2000,5000,10000,20000,50000,100000,200000,500000)
            AND Quantity >= 0
        )
    );

    /* 11. Một đơn có tối đa một thanh toán thành công. Đơn miễn phí có tổng bằng 0. */
    CREATE TABLE dbo.Orders
    (
        OrderId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Orders PRIMARY KEY,
        OrderCode varchar(40) NOT NULL CONSTRAINT UQ_Orders_Code UNIQUE,
        ShowtimeId int NULL,
        MemberId int NULL,
        CreatedByUserId int NOT NULL,
        ShiftId int NULL,
        SalesChannel varchar(8) NOT NULL,
        Status varchar(16) NOT NULL CONSTRAINT DF_Orders_Status DEFAULT ('Draft'),
        Subtotal decimal(19,0) NOT NULL CONSTRAINT DF_Orders_Subtotal DEFAULT (0),
        RewardDiscount decimal(19,0) NOT NULL CONSTRAINT DF_Orders_RewardDiscount DEFAULT (0),
        TotalAmount AS (CONVERT(decimal(19,0), Subtotal - RewardDiscount)) PERSISTED,
        PaymentMethod varchar(8) NULL,
        BankReference nvarchar(100) NULL,
        CashReceived decimal(19,0) NULL,
        CashChange AS (CashReceived - (Subtotal - RewardDiscount)),
        CreatedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_Orders_Created DEFAULT (SYSUTCDATETIME()),
        PaidAtUtc datetime2(0) NULL,
        CONSTRAINT FK_Orders_Members FOREIGN KEY (MemberId) REFERENCES dbo.Members(MemberId),
        CONSTRAINT FK_Orders_Showtimes FOREIGN KEY (ShowtimeId) REFERENCES dbo.Showtimes(ShowtimeId),
        CONSTRAINT FK_Orders_CreatedBy FOREIGN KEY (CreatedByUserId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT FK_Orders_EmployeeShift FOREIGN KEY (CreatedByUserId, ShiftId)
            REFERENCES dbo.Shifts(EmployeeUserId, ShiftId),
        CONSTRAINT UQ_Orders_Showtime_Order UNIQUE (ShowtimeId, OrderId),
        CONSTRAINT UQ_Orders_Member_Order UNIQUE (MemberId, OrderId),
        CONSTRAINT UQ_Orders_Order_Total UNIQUE (OrderId, TotalAmount),
        CONSTRAINT CK_Orders_SalesChannel CHECK
        (
            (SalesChannel = 'POS' AND ShiftId IS NOT NULL)
            OR (SalesChannel = 'Web' AND ShiftId IS NULL AND MemberId IS NOT NULL AND ShowtimeId IS NOT NULL)
        ),
        CONSTRAINT CK_Orders_Amounts CHECK
        (
            LEN(OrderCode) > 0 AND Subtotal >= 0 AND RewardDiscount BETWEEN 0 AND Subtotal
            AND (RewardDiscount = 0 OR MemberId IS NOT NULL)
        ),
        CONSTRAINT CK_Orders_Payment CHECK
        (
            (Status IN ('Draft','PendingPayment','Cancelled') AND PaidAtUtc IS NULL
                AND PaymentMethod IS NULL AND BankReference IS NULL AND CashReceived IS NULL)
            OR (Status IN ('Paid','Refunded') AND PaidAtUtc IS NOT NULL AND PaidAtUtc >= CreatedAtUtc
                AND
                (
                    (Subtotal = RewardDiscount AND PaymentMethod IS NULL
                        AND BankReference IS NULL AND CashReceived IS NULL)
                    OR (Subtotal > RewardDiscount AND PaymentMethod IS NOT NULL
                        AND
                        (
                            (PaymentMethod = 'Cash' AND SalesChannel = 'POS' AND BankReference IS NULL
                                AND CashReceived IS NOT NULL AND CashReceived >= Subtotal - RewardDiscount)
                            OR (PaymentMethod = 'VietQR' AND BankReference IS NOT NULL
                                AND LEN(BankReference) > 0 AND CashReceived IS NULL)
                        ))
                ))
        )
    );

    /* 12. Một dòng cho mỗi ghế mở bán của suất. Ghế đã bán xác định từ vé còn hiệu lực. */
    CREATE TABLE dbo.ShowtimeSeats
    (
        ShowtimeId int NOT NULL,
        SeatId int NOT NULL,
        AuditoriumId int NOT NULL,
        SeatType varchar(12) NOT NULL,
        IsBlocked bit NOT NULL CONSTRAINT DF_ShowtimeSeats_IsBlocked DEFAULT (0),
        HeldByOrderId int NULL,
        HoldUntilUtc datetime2(0) NULL,
        [Version] rowversion NOT NULL,
        CONSTRAINT PK_ShowtimeSeats PRIMARY KEY (ShowtimeId, SeatId),
        CONSTRAINT FK_ShowtimeSeats_ShowtimeRoom FOREIGN KEY (AuditoriumId, ShowtimeId)
            REFERENCES dbo.Showtimes(AuditoriumId, ShowtimeId),
        CONSTRAINT FK_ShowtimeSeats_SeatRoom FOREIGN KEY (AuditoriumId, SeatId)
            REFERENCES dbo.Seats(AuditoriumId, SeatId),
        CONSTRAINT FK_ShowtimeSeats_HoldOrder FOREIGN KEY (ShowtimeId, HeldByOrderId)
            REFERENCES dbo.Orders(ShowtimeId, OrderId),
        CONSTRAINT CK_ShowtimeSeats_SeatType CHECK (SeatType IN ('Standard','VIP','Sweetbox')),
        CONSTRAINT CK_ShowtimeSeats_Hold CHECK
        (
            (HeldByOrderId IS NULL AND HoldUntilUtc IS NULL)
            OR (HeldByOrderId IS NOT NULL AND HoldUntilUtc IS NOT NULL AND IsBlocked = 0)
        )
    );

    /* 13. Chốt tên và giá tại thời điểm bán để giữ đúng lịch sử hóa đơn. */
    CREATE TABLE dbo.OrderProducts
    (
        OrderProductId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_OrderProducts PRIMARY KEY,
        OrderId int NOT NULL,
        ProductId int NOT NULL,
        ProductNameAtSale nvarchar(160) NOT NULL,
        Quantity int NOT NULL,
        UnitPrice decimal(19,0) NOT NULL,
        LineAmount AS (UnitPrice * Quantity),
        FulfilledAtUtc datetime2(0) NULL,
        CONSTRAINT FK_OrderProducts_Orders FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId),
        CONSTRAINT FK_OrderProducts_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId),
        CONSTRAINT UQ_OrderProducts_Order_Product UNIQUE (OrderId, ProductId),
        CONSTRAINT UQ_OrderProducts_Product_Line UNIQUE (ProductId, OrderProductId),
        CONSTRAINT CK_OrderProducts_Values CHECK
        (
            LEN(ProductNameAtSale) > 0 AND Quantity > 0 AND UnitPrice >= 0
        )
    );

    /* 14. Sổ điểm. Earn/Reverse tác động cả hai số dư. Redeem/Restore chỉ tác động điểm tiêu dùng. */
    CREATE TABLE dbo.PointTransactions
    (
        PointTransactionId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PointTransactions PRIMARY KEY,
        MemberId int NOT NULL,
        OrderId int NULL,
        EntryType varchar(12) NOT NULL,
        TierPointsDelta bigint NOT NULL,
        SpendablePointsDelta bigint NOT NULL,
        SourcePointTransactionId int NULL,
        SourceEntryType AS (CONVERT(varchar(12),
            CASE EntryType WHEN 'Reverse' THEN 'Earn' WHEN 'Restore' THEN 'Redeem' END)) PERSISTED,
        SourceTierPointsDelta AS (CASE
            WHEN EntryType = 'Reverse' AND TierPointsDelta < 0 THEN -TierPointsDelta
            WHEN EntryType = 'Restore' THEN CONVERT(bigint, 0) END) PERSISTED,
        SourceSpendablePointsDelta AS (CASE
            WHEN EntryType = 'Reverse' AND SpendablePointsDelta < 0 THEN -SpendablePointsDelta
            WHEN EntryType = 'Restore' AND SpendablePointsDelta > 0 THEN -SpendablePointsDelta END) PERSISTED,
        Note nvarchar(400) NULL,
        CreatedByUserId int NULL,
        CreatedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_PointTransactions_Created DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_PointTransactions_Members FOREIGN KEY (MemberId) REFERENCES dbo.Members(MemberId),
        CONSTRAINT FK_PointTransactions_MemberOrder FOREIGN KEY (MemberId, OrderId)
            REFERENCES dbo.Orders(MemberId, OrderId),
        CONSTRAINT FK_PointTransactions_CreatedBy FOREIGN KEY (CreatedByUserId)
            REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT UQ_PointTransactions_Member_Entry_Type UNIQUE (MemberId, PointTransactionId, EntryType),
        CONSTRAINT UQ_PointTransactions_Source UNIQUE
            (MemberId, PointTransactionId, EntryType, TierPointsDelta, SpendablePointsDelta),
        CONSTRAINT FK_PointTransactions_Source FOREIGN KEY
            (MemberId, SourcePointTransactionId, SourceEntryType, SourceTierPointsDelta, SourceSpendablePointsDelta)
            REFERENCES dbo.PointTransactions(MemberId, PointTransactionId, EntryType, TierPointsDelta, SpendablePointsDelta),
        CONSTRAINT CK_PointTransactions_Values CHECK
        (
            (EntryType = 'Earn' AND OrderId IS NOT NULL AND SourcePointTransactionId IS NULL
                AND TierPointsDelta > 0 AND SpendablePointsDelta > 0)
            OR (EntryType = 'Reverse' AND OrderId IS NOT NULL AND SourcePointTransactionId IS NOT NULL
                AND TierPointsDelta < 0 AND SpendablePointsDelta < 0)
            OR (EntryType = 'Redeem' AND SourcePointTransactionId IS NULL
                AND TierPointsDelta = 0 AND SpendablePointsDelta < 0)
            OR (EntryType = 'Restore' AND SourcePointTransactionId IS NOT NULL
                AND TierPointsDelta = 0 AND SpendablePointsDelta > 0)
            OR (EntryType = 'Adjust' AND SourcePointTransactionId IS NULL
                AND (TierPointsDelta <> 0 OR SpendablePointsDelta <> 0)
                AND Note IS NOT NULL AND LEN(Note) > 0 AND CreatedByUserId IS NOT NULL)
        )
    );

    /* 15. Mỗi lượt đổi điểm cấp đúng một quyền đổi vé miễn phí. Chi phí nằm ở dòng Redeem. */
    CREATE TABLE dbo.MemberRewards
    (
        MemberRewardId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_MemberRewards PRIMARY KEY,
        MemberId int NOT NULL,
        SourcePointTransactionId int NOT NULL,
        SourceEntryType varchar(12) NOT NULL CONSTRAINT DF_MemberRewards_SourceType DEFAULT ('Redeem'),
        RedeemedTierCode varchar(12) NOT NULL,
        Status varchar(12) NOT NULL CONSTRAINT DF_MemberRewards_Status DEFAULT ('Available'),
        GrantedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_MemberRewards_Granted DEFAULT (SYSUTCDATETIME()),
        ExpiresAtUtc datetime2(0) NULL,
        UsedAtUtc datetime2(0) NULL,
        RevokedAtUtc datetime2(0) NULL,
        CONSTRAINT FK_MemberRewards_Source FOREIGN KEY (MemberId, SourcePointTransactionId, SourceEntryType)
            REFERENCES dbo.PointTransactions(MemberId, PointTransactionId, EntryType),
        CONSTRAINT UQ_MemberRewards_Source UNIQUE (SourcePointTransactionId),
        CONSTRAINT UQ_MemberRewards_Member_Reward UNIQUE (MemberId, MemberRewardId),
        CONSTRAINT CK_MemberRewards_SourceType CHECK (SourceEntryType = 'Redeem'),
        CONSTRAINT CK_MemberRewards_Tier CHECK (RedeemedTierCode IN ('Silver','Gold','Diamond')),
        CONSTRAINT CK_MemberRewards_Dates CHECK
        (
            (ExpiresAtUtc IS NULL OR ExpiresAtUtc > GrantedAtUtc)
            AND (UsedAtUtc IS NULL OR
                (UsedAtUtc >= GrantedAtUtc AND (ExpiresAtUtc IS NULL OR UsedAtUtc < ExpiresAtUtc)))
            AND (RevokedAtUtc IS NULL OR
                (RevokedAtUtc >= GrantedAtUtc AND (UsedAtUtc IS NULL OR RevokedAtUtc >= UsedAtUtc)))
        ),
        CONSTRAINT CK_MemberRewards_Status CHECK
        (
            (Status = 'Available' AND UsedAtUtc IS NULL AND RevokedAtUtc IS NULL)
            OR (Status = 'Expired' AND UsedAtUtc IS NULL AND ExpiresAtUtc IS NOT NULL AND RevokedAtUtc IS NULL)
            OR (Status = 'Used' AND UsedAtUtc IS NOT NULL AND RevokedAtUtc IS NULL)
            OR (Status = 'Revoked' AND RevokedAtUtc IS NOT NULL)
        )
    );

    /* 16. Mã vé và mã QR là duy nhất. Vé đã hủy giữ lại để tra cứu lịch sử. */
    CREATE TABLE dbo.Tickets
    (
        TicketId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Tickets PRIMARY KEY,
        TicketCode varchar(40) NOT NULL CONSTRAINT UQ_Tickets_Code UNIQUE,
        QrToken uniqueidentifier NOT NULL CONSTRAINT DF_Tickets_QrToken DEFAULT (NEWID())
            CONSTRAINT UQ_Tickets_QrToken UNIQUE,
        OrderId int NOT NULL,
        ShowtimeId int NOT NULL,
        SeatId int NOT NULL,
        MemberId int NULL,
        MemberRewardId int NULL,
        SeatCodeAtSale varchar(16) NOT NULL,
        SeatTypeAtSale varchar(12) NOT NULL,
        FacePrice decimal(19,0) NOT NULL,
        RewardDiscount AS (CONVERT(decimal(19,0), CASE WHEN MemberRewardId IS NULL THEN 0 ELSE FacePrice END)),
        PaidAmount AS (CONVERT(decimal(19,0), CASE WHEN MemberRewardId IS NULL THEN FacePrice ELSE 0 END)),
        IssuedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_Tickets_Issued DEFAULT (SYSUTCDATETIME()),
        CheckedInAtUtc datetime2(0) NULL,
        CheckedInByUserId int NULL,
        CancelledAtUtc datetime2(0) NULL,
        CONSTRAINT FK_Tickets_MemberReward FOREIGN KEY (MemberId, MemberRewardId)
            REFERENCES dbo.MemberRewards(MemberId, MemberRewardId),
        CONSTRAINT FK_Tickets_MemberOrder FOREIGN KEY (MemberId, OrderId)
            REFERENCES dbo.Orders(MemberId, OrderId),
        CONSTRAINT FK_Tickets_OrderShowtime FOREIGN KEY (ShowtimeId, OrderId)
            REFERENCES dbo.Orders(ShowtimeId, OrderId),
        CONSTRAINT FK_Tickets_ShowtimeSeats FOREIGN KEY (ShowtimeId, SeatId)
            REFERENCES dbo.ShowtimeSeats(ShowtimeId, SeatId),
        CONSTRAINT FK_Tickets_CheckedInBy FOREIGN KEY (CheckedInByUserId)
            REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_Tickets_Details CHECK
        (
            LEN(TicketCode) > 0 AND LEN(SeatCodeAtSale) > 0
            AND SeatTypeAtSale IN ('Standard','VIP','Sweetbox') AND FacePrice >= 0
            AND (MemberRewardId IS NULL OR (MemberId IS NOT NULL AND FacePrice > 0))
        ),
        CONSTRAINT CK_Tickets_Usage CHECK
        (
            ((CheckedInAtUtc IS NULL AND CheckedInByUserId IS NULL)
                OR (CheckedInAtUtc IS NOT NULL AND CheckedInByUserId IS NOT NULL
                    AND CheckedInAtUtc >= IssuedAtUtc))
            AND (CancelledAtUtc IS NULL OR (CancelledAtUtc >= IssuedAtUtc AND CheckedInAtUtc IS NULL))
        )
    );

    /* 17. Nhân viên/khách gửi yêu cầu. Quản lý duyệt. Người thực chi được ghi riêng. */
    CREATE TABLE dbo.RefundRequests
    (
        RefundRequestId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_RefundRequests PRIMARY KEY,
        RequestCode varchar(32) NOT NULL CONSTRAINT UQ_RefundRequests_Code UNIQUE,
        OrderId int NOT NULL,
        RequestedByUserId int NOT NULL,
        RequestedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_RefundRequests_Requested DEFAULT (SYSUTCDATETIME()),
        Reason nvarchar(400) NOT NULL,
        RequestNote nvarchar(400) NULL,
        Status varchar(16) NOT NULL CONSTRAINT DF_RefundRequests_Status DEFAULT ('Pending'),
        ApprovedOrRejectedByUserId int NULL,
        ReviewedAtUtc datetime2(0) NULL,
        ReviewNote nvarchar(400) NULL,
        PaidOrderAmount decimal(19,0) NOT NULL,
        RefundFee decimal(19,0) NOT NULL CONSTRAINT DF_RefundRequests_Fee DEFAULT (0),
        RefundAmount AS (PaidOrderAmount - RefundFee),
        RefundMethod varchar(8) NULL,
        BankRefundReference nvarchar(100) NULL,
        ProcessedByUserId int NULL,
        ProcessedAtUtc datetime2(0) NULL,
        CashRefundShiftId int NULL,
        CONSTRAINT FK_RefundRequests_Orders FOREIGN KEY (OrderId, PaidOrderAmount)
            REFERENCES dbo.Orders(OrderId, TotalAmount),
        CONSTRAINT FK_RefundRequests_RequestedBy FOREIGN KEY (RequestedByUserId)
            REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT FK_RefundRequests_ReviewedBy FOREIGN KEY (ApprovedOrRejectedByUserId)
            REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT FK_RefundRequests_ProcessedBy FOREIGN KEY (ProcessedByUserId)
            REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT FK_RefundRequests_CashShift FOREIGN KEY (CashRefundShiftId) REFERENCES dbo.Shifts(ShiftId),
        CONSTRAINT CK_RefundRequests_Values CHECK
        (
            LEN(RequestCode) > 0 AND LEN(Reason) > 0 AND PaidOrderAmount >= 0
            AND RefundFee BETWEEN 0 AND PaidOrderAmount
            AND (RequestNote IS NULL OR LEN(RequestNote) > 0)
        ),
        CONSTRAINT CK_RefundRequests_Review CHECK
        (
            (Status = 'Pending' AND ApprovedOrRejectedByUserId IS NULL AND ReviewedAtUtc IS NULL)
            OR (Status IN ('Approved','Rejected','Refunded')
                AND ApprovedOrRejectedByUserId IS NOT NULL
                AND ApprovedOrRejectedByUserId <> RequestedByUserId
                AND ReviewedAtUtc IS NOT NULL AND ReviewedAtUtc >= RequestedAtUtc)
        ),
        CONSTRAINT CK_RefundRequests_Payout CHECK
        (
            (Status IN ('Pending','Approved','Rejected') AND ProcessedByUserId IS NULL AND ProcessedAtUtc IS NULL
                AND RefundMethod IS NULL AND BankRefundReference IS NULL AND CashRefundShiftId IS NULL)
            OR (Status = 'Refunded' AND ProcessedByUserId IS NOT NULL AND ProcessedAtUtc IS NOT NULL
                AND ProcessedAtUtc >= ReviewedAtUtc AND
                (
                    (PaidOrderAmount = RefundFee AND RefundMethod IS NULL
                        AND BankRefundReference IS NULL AND CashRefundShiftId IS NULL)
                    OR (PaidOrderAmount > RefundFee AND RefundMethod IS NOT NULL AND
                        (
                            (RefundMethod = 'Cash' AND CashRefundShiftId IS NOT NULL AND BankRefundReference IS NULL)
                            OR (RefundMethod = 'VietQR' AND CashRefundShiftId IS NULL
                                AND BankRefundReference IS NOT NULL AND LEN(BankRefundReference) > 0)
                        ))
                ))
        )
    );

    /* 18. Nhật ký nhận cả lượt quét lỗi, kể cả khi mã không khớp với vé nào. */
    CREATE TABLE dbo.TicketScanLogs
    (
        TicketScanLogId bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_TicketScanLogs PRIMARY KEY,
        GateShowtimeId int NOT NULL,
        TicketId int NULL,
        EmployeeUserId int NOT NULL,
        ScanInput nvarchar(200) NOT NULL,
        ResultCode varchar(16) NOT NULL,
        Note nvarchar(300) NULL,
        ScannedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_TicketScanLogs_Scanned DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_TicketScanLogs_GateShowtime FOREIGN KEY (GateShowtimeId) REFERENCES dbo.Showtimes(ShowtimeId),
        CONSTRAINT FK_TicketScanLogs_Ticket FOREIGN KEY (TicketId) REFERENCES dbo.Tickets(TicketId),
        CONSTRAINT FK_TicketScanLogs_Employee FOREIGN KEY (EmployeeUserId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_TicketScanLogs_Result CHECK
        (
            LEN(ScanInput) > 0 AND
            (
                (ResultCode = 'NotFound' AND TicketId IS NULL)
                OR (ResultCode IN ('Valid','Admitted','AlreadyUsed','WrongShowtime','NotInWindow','Cancelled')
                    AND TicketId IS NOT NULL)
            )
        )
    );

    /* 19. Tồn kho tính từ tổng biến động. Mỗi dòng nhập hàng lưu một mặt hàng. */
    CREATE TABLE dbo.StockMovements
    (
        StockMovementId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_StockMovements PRIMARY KEY,
        ProductId int NOT NULL,
        OrderProductId int NULL,
        MovementType varchar(12) NOT NULL,
        QuantityDelta int NOT NULL,
        UnitCost decimal(19,0) NULL,
        SupplierName nvarchar(160) NULL,
        Note nvarchar(400) NULL,
        CreatedByUserId int NOT NULL,
        CreatedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_StockMovements_Created DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_StockMovements_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId),
        CONSTRAINT FK_StockMovements_OrderProduct FOREIGN KEY (ProductId, OrderProductId)
            REFERENCES dbo.OrderProducts(ProductId, OrderProductId),
        CONSTRAINT FK_StockMovements_CreatedBy FOREIGN KEY (CreatedByUserId)
            REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_StockMovements_Values CHECK
        (
            (MovementType = 'Receipt' AND QuantityDelta > 0 AND OrderProductId IS NULL
                AND UnitCost IS NOT NULL AND UnitCost >= 0 AND SupplierName IS NOT NULL AND LEN(SupplierName) > 0)
            OR (MovementType = 'Sale' AND QuantityDelta < 0 AND OrderProductId IS NOT NULL
                AND UnitCost IS NULL AND SupplierName IS NULL)
            OR (MovementType = 'Return' AND QuantityDelta > 0 AND OrderProductId IS NOT NULL
                AND UnitCost IS NULL AND SupplierName IS NULL)
            OR (MovementType = 'Adjust' AND QuantityDelta <> 0 AND OrderProductId IS NULL
                AND UnitCost IS NULL AND SupplierName IS NULL AND Note IS NOT NULL AND LEN(Note) > 0)
        )
    );

    /* 20. Một dòng cấu hình nghiệp vụ cho toàn rạp. Bí mật tích hợp lưu ngoài CSDL. */
    CREATE TABLE dbo.CinemaSettings
    (
        CinemaSettingsId tinyint NOT NULL CONSTRAINT PK_CinemaSettings PRIMARY KEY,
        CinemaName nvarchar(120) NOT NULL,
        Address nvarchar(250) NOT NULL,
        Hotline varchar(24) NULL,
        OpensAtLocal time(0) NOT NULL,
        ClosesAtLocal time(0) NOT NULL,
        SeatHoldMinutes smallint NOT NULL,
        SalesCutoffMinutes smallint NOT NULL,
        RefundCutoffMinutes smallint NOT NULL,
        FixedRefundFee decimal(19,0) NOT NULL,
        GateOpensBeforeMinutes smallint NOT NULL,
        GateClosesAfterStartMinutes smallint NOT NULL,
        CONSTRAINT CK_CinemaSettings_SingleRow CHECK (CinemaSettingsId = 1),
        CONSTRAINT CK_CinemaSettings_Values CHECK
        (
            LEN(CinemaName) > 0 AND LEN(Address) > 0 AND OpensAtLocal <> ClosesAtLocal
            AND SeatHoldMinutes > 0 AND SalesCutoffMinutes >= 0
            AND RefundCutoffMinutes >= 0 AND FixedRefundFee >= 0
            AND GateOpensBeforeMinutes >= 0 AND GateClosesAfterStartMinutes >= 0
        )
    );

    /* 21. Quyền theo vai trò và mã chức năng. Mỗi dòng cấp một quyền. */
    CREATE TABLE dbo.RolePermissions
    (
        RoleCode varchar(16) NOT NULL,
        FeatureCode varchar(50) NOT NULL,
        ActionCode varchar(20) NOT NULL,
        UpdatedByUserId int NULL,
        UpdatedAtUtc datetime2(0) NOT NULL CONSTRAINT DF_RolePermissions_Updated DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_RolePermissions PRIMARY KEY (RoleCode, FeatureCode, ActionCode),
        CONSTRAINT FK_RolePermissions_UpdatedBy FOREIGN KEY (UpdatedByUserId)
            REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_RolePermissions_Values CHECK
        (
            RoleCode IN ('Admin','Manager','Employee')
            AND LEN(FeatureCode) > 0
            AND ActionCode IN ('View','Create','Edit','Delete','Approve','Reject','Confirm','Export','Print')
        )
    );

    /* 22. Nhật ký thay đổi nghiệp vụ. EntityKey hỗ trợ khóa của nhiều loại đối tượng. */
    CREATE TABLE dbo.AuditLogs
    (
        AuditLogId bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_AuditLogs PRIMARY KEY,
        ActorUserId int NULL,
        ActionCode varchar(40) NOT NULL,
        EntityType varchar(50) NOT NULL,
        EntityKey nvarchar(120) NOT NULL,
        DetailsJson nvarchar(max) NULL,
        OccurredAtUtc datetime2(0) NOT NULL CONSTRAINT DF_AuditLogs_Occurred DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_AuditLogs_Actor FOREIGN KEY (ActorUserId) REFERENCES dbo.UserAccounts(UserAccountId),
        CONSTRAINT CK_AuditLogs_Values CHECK
        (
            LEN(ActionCode) > 0 AND LEN(EntityType) > 0 AND LEN(EntityKey) > 0
            AND (DetailsJson IS NULL OR ISJSON(DetailsJson) = 1)
        )
    );

    /* Chỉ mục UNIQUE có điều kiện cho giá trị tùy chọn và trạng thái đang hiệu lực. */
    CREATE UNIQUE INDEX UX_UserAccounts_Email ON dbo.UserAccounts(Email) WHERE Email IS NOT NULL;
    CREATE UNIQUE INDEX UX_UserAccounts_Phone ON dbo.UserAccounts(Phone) WHERE Phone IS NOT NULL;
    CREATE UNIQUE INDEX UX_UserAccounts_EmployeeCode ON dbo.UserAccounts(EmployeeCode) WHERE EmployeeCode IS NOT NULL;
    CREATE UNIQUE INDEX UX_Members_User ON dbo.Members(UserAccountId) WHERE UserAccountId IS NOT NULL;
    CREATE UNIQUE INDEX UX_Members_Email ON dbo.Members(Email) WHERE Email IS NOT NULL;
    CREATE UNIQUE INDEX UX_Shifts_OpenEmployee ON dbo.Shifts(EmployeeUserId) WHERE Status = 'Open';
    CREATE UNIQUE INDEX UX_Shifts_OpenTerminal ON dbo.Shifts(TerminalCode) WHERE Status = 'Open';
    CREATE UNIQUE INDEX UX_Showtimes_RoomStart ON dbo.Showtimes(AuditoriumId, StartsAtUtc)
        WHERE SalesStatus <> 'Cancelled';
    CREATE UNIQUE INDEX UX_Orders_BankReference ON dbo.Orders(BankReference) WHERE BankReference IS NOT NULL;
    CREATE UNIQUE INDEX UX_Tickets_ActiveSeat ON dbo.Tickets(ShowtimeId, SeatId) WHERE CancelledAtUtc IS NULL;
    CREATE UNIQUE INDEX UX_RefundRequests_ActiveOrder ON dbo.RefundRequests(OrderId) WHERE Status <> 'Rejected';
    CREATE UNIQUE INDEX UX_RefundRequests_BankReference ON dbo.RefundRequests(BankRefundReference)
        WHERE BankRefundReference IS NOT NULL;
    CREATE UNIQUE INDEX UX_PointTransactions_OrderEntry ON dbo.PointTransactions(OrderId, EntryType)
        WHERE OrderId IS NOT NULL AND EntryType IN ('Earn','Reverse');
    CREATE UNIQUE INDEX UX_PointTransactions_Source ON dbo.PointTransactions(SourcePointTransactionId)
        WHERE SourcePointTransactionId IS NOT NULL;
    CREATE UNIQUE INDEX UX_Tickets_MemberReward ON dbo.Tickets(MemberRewardId) WHERE MemberRewardId IS NOT NULL;
    CREATE UNIQUE INDEX UX_TicketScanLogs_Admitted ON dbo.TicketScanLogs(TicketId) WHERE ResultCode = 'Admitted';
    CREATE UNIQUE INDEX UX_StockMovements_OrderEntry ON dbo.StockMovements(OrderProductId, MovementType)
        WHERE OrderProductId IS NOT NULL;

    /* Chỉ mục phục vụ tra cứu và đối soát. */
    CREATE INDEX IX_Showtimes_MovieStart ON dbo.Showtimes(MovieId, StartsAtUtc);
    CREATE INDEX IX_TicketPriceRules_Showtime ON dbo.TicketPriceRules(ShowtimeId, IsActive);
    CREATE INDEX IX_ShowtimeSeats_HoldOrder ON dbo.ShowtimeSeats(HeldByOrderId, HoldUntilUtc)
        WHERE HeldByOrderId IS NOT NULL;
    CREATE INDEX IX_Orders_Created ON dbo.Orders(CreatedAtUtc);
    CREATE INDEX IX_Orders_MemberCreated ON dbo.Orders(MemberId, CreatedAtUtc);
    CREATE INDEX IX_Orders_ShiftStatus ON dbo.Orders(ShiftId, Status);
    CREATE INDEX IX_Tickets_Order ON dbo.Tickets(OrderId);
    CREATE INDEX IX_RefundRequests_StatusTime ON dbo.RefundRequests(Status, RequestedAtUtc);
    CREATE INDEX IX_RefundRequests_CashShift ON dbo.RefundRequests(CashRefundShiftId, ProcessedAtUtc);
    CREATE INDEX IX_PointTransactions_MemberTime ON dbo.PointTransactions(MemberId, CreatedAtUtc);
    CREATE INDEX IX_MemberRewards_MemberStatus ON dbo.MemberRewards(MemberId, Status);
    CREATE INDEX IX_TicketScanLogs_GateTime ON dbo.TicketScanLogs(GateShowtimeId, ScannedAtUtc);
    CREATE INDEX IX_StockMovements_ProductTime ON dbo.StockMovements(ProductId, CreatedAtUtc);
    CREATE INDEX IX_AuditLogs_EntityTime ON dbo.AuditLogs(EntityType, EntityKey, OccurredAtUtc);


    /* Tạo trigger trong cùng transaction khởi tạo schema. */
    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_Showtimes_NoOverlap ON dbo.Showtimes
AFTER INSERT, UPDATE AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        JOIN dbo.Showtimes AS s WITH (UPDLOCK, HOLDLOCK)
            ON s.AuditoriumId = i.AuditoriumId AND s.ShowtimeId <> i.ShowtimeId
            AND s.StartsAtUtc < i.RoomBusyUntilUtc AND i.StartsAtUtc < s.RoomBusyUntilUtc
        WHERE i.SalesStatus <> ''Cancelled'' AND s.SalesStatus <> ''Cancelled''
    )
        THROW 51100, N''Hai suất còn hiệu lực bị chồng giờ trong cùng phòng.'', 1;
END;';

    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_PointTransactions_UpdateBalances ON dbo.PointTransactions
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM deleted)
        THROW 51101, N''Sổ điểm chỉ được thêm dòng. Hãy dùng giao dịch đảo hoặc điều chỉnh.'', 1;

    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN dbo.Orders AS o WITH (UPDLOCK, HOLDLOCK) ON o.OrderId = i.OrderId
        LEFT JOIN dbo.PointTransactions AS src ON src.PointTransactionId = i.SourcePointTransactionId
        WHERE (i.EntryType = ''Earn'' AND o.Status <> ''Paid'')
            OR (i.EntryType = ''Reverse'' AND (o.Status <> ''Refunded'' OR i.OrderId <> src.OrderId))
    )
        THROW 51102, N''Chỉ tích điểm cho đơn đã thanh toán và đảo điểm gốc của đúng đơn đã hoàn.'', 1;

    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN dbo.MemberRewards AS r WITH (UPDLOCK, HOLDLOCK)
            ON r.SourcePointTransactionId = i.SourcePointTransactionId
        LEFT JOIN dbo.Tickets AS t WITH (UPDLOCK, HOLDLOCK) ON t.MemberRewardId = r.MemberRewardId
        WHERE i.EntryType = ''Restore''
            AND (r.MemberRewardId IS NULL OR r.Status NOT IN (''Expired'',''Revoked'')
                OR (t.TicketId IS NOT NULL AND t.CancelledAtUtc IS NULL))
    )
        THROW 51103, N''Chỉ hoàn điểm cho quyền đã hết hạn hoặc thu hồi và không còn vé hiệu lực.'', 1;

    ;WITH Deltas AS
    (
        SELECT MemberId, SUM(TierPointsDelta) AS TierDelta, SUM(SpendablePointsDelta) AS SpendableDelta
        FROM inserted
        GROUP BY MemberId
    )
    UPDATE m
    SET TierPoints = m.TierPoints + d.TierDelta,
        SpendablePoints = m.SpendablePoints + d.SpendableDelta
    FROM dbo.Members AS m
    JOIN Deltas AS d ON d.MemberId = m.MemberId;
END;';

    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_Members_ProtectPoints ON dbo.Members
AFTER INSERT, UPDATE AS
BEGIN
    SET NOCOUNT ON;
    IF TRIGGER_NESTLEVEL(OBJECT_ID(N''dbo.TR_PointTransactions_UpdateBalances'')) > 0
        RETURN;

    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.MemberId = i.MemberId
        WHERE i.TierPoints <> ISNULL(d.TierPoints, 0)
            OR i.SpendablePoints <> ISNULL(d.SpendablePoints, 0)
            OR (d.MemberId IS NULL AND i.TierCode <> ''Silver'')
    )
        THROW 51104, N''Thành viên mới bắt đầu hạng Bạc, 0 điểm. Thay đổi số dư qua sổ điểm.'', 1;
END;';

    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_MemberRewards_ProtectUsage ON dbo.MemberRewards
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS
    (
        SELECT 1
        FROM deleted AS d LEFT JOIN inserted AS i ON i.MemberRewardId = d.MemberRewardId
        WHERE i.MemberRewardId IS NULL OR i.MemberId <> d.MemberId
            OR i.SourcePointTransactionId <> d.SourcePointTransactionId OR i.RedeemedTierCode <> d.RedeemedTierCode
            OR i.GrantedAtUtc <> d.GrantedAtUtc
            OR (d.Status = ''Revoked'' AND i.Status <> ''Revoked'')
            OR (d.Status = ''Expired'' AND i.Status NOT IN (''Expired'',''Revoked''))
            OR (d.Status = ''Used'' AND i.Status NOT IN (''Used'',''Revoked''))
            OR (d.UsedAtUtc IS NOT NULL AND (i.UsedAtUtc IS NULL OR i.UsedAtUtc <> d.UsedAtUtc))
            OR (d.RevokedAtUtc IS NOT NULL AND (i.RevokedAtUtc IS NULL OR i.RevokedAtUtc <> d.RevokedAtUtc))
    )
        THROW 51105, N''Không được xóa quyền đổi vé hoặc sửa lại giao dịch và lịch sử sử dụng.'', 1;

    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.MemberRewardId = i.MemberRewardId
        JOIN dbo.Members AS m ON m.MemberId = i.MemberId
        WHERE (d.MemberRewardId IS NULL AND (i.Status <> ''Available'' OR i.RedeemedTierCode <> m.TierCode))
            OR (i.Status = ''Expired'' AND i.ExpiresAtUtc > SYSUTCDATETIME())
            OR (i.Status = ''Used'' AND (d.Status IS NULL OR d.Status <> ''Used'')
                AND TRIGGER_NESTLEVEL(OBJECT_ID(N''dbo.TR_Tickets_UseMemberReward'')) = 0)
    )
        THROW 51106, N''Cấp quyền theo hạng hiện tại và chỉ dùng quyền khi phát hành vé.'', 1;
END;';

    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_Tickets_UseMemberReward ON dbo.Tickets
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM deleted AS d LEFT JOIN inserted AS i ON i.TicketId = d.TicketId
        WHERE (i.TicketId IS NULL AND d.MemberRewardId IS NOT NULL)
            OR ISNULL(i.MemberRewardId, 0) <> ISNULL(d.MemberRewardId, 0)
            OR (d.MemberRewardId IS NOT NULL AND (i.FacePrice <> d.FacePrice OR i.MemberId <> d.MemberId
                OR i.OrderId <> d.OrderId OR i.IssuedAtUtc <> d.IssuedAtUtc
                OR (d.CancelledAtUtc IS NOT NULL AND i.CancelledAtUtc IS NULL)))
    )
        THROW 51107, N''Quyền đổi vé gắn cố định khi phát hành. Hủy vé để giữ lịch sử.'', 1;

    DECLARE @Expected int =
    (
        SELECT COUNT(*) FROM inserted AS i
        LEFT JOIN deleted AS d ON d.TicketId = i.TicketId
        WHERE d.TicketId IS NULL AND i.MemberRewardId IS NOT NULL
    );

    IF @Expected = 0
        RETURN;

    DECLARE @NowUtc datetime2(0) = SYSUTCDATETIME();
    UPDATE r
    SET Status = ''Used'', UsedAtUtc = @NowUtc
    FROM dbo.MemberRewards AS r
    JOIN inserted AS i ON i.MemberRewardId = r.MemberRewardId
    LEFT JOIN deleted AS d ON d.TicketId = i.TicketId
    WHERE d.TicketId IS NULL AND i.CancelledAtUtc IS NULL AND r.Status = ''Available''
        AND r.GrantedAtUtc <= @NowUtc AND (r.ExpiresAtUtc IS NULL OR @NowUtc < r.ExpiresAtUtc);

    IF @@ROWCOUNT <> @Expected
        THROW 51108, N''Quyền đổi vé đã dùng, hết hạn hoặc không còn hiệu lực.'', 1;
END;';

    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_RefundRequests_VerifyOrder ON dbo.RefundRequests
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM deleted WHERE Status = ''Refunded'')
        THROW 51112, N''Yêu cầu đã thực chi được giữ nguyên để đối soát.'', 1;

    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        JOIN dbo.Orders AS o WITH (UPDLOCK, HOLDLOCK) ON o.OrderId = i.OrderId
        WHERE o.Status NOT IN (''Paid'',''Refunded'')
            OR (o.Status = ''Refunded'' AND i.Status <> ''Refunded'')
            OR (i.Status = ''Refunded'' AND i.RefundAmount > 0
                AND (o.PaymentMethod IS NULL OR i.RefundMethod <> o.PaymentMethod))
    )
        THROW 51109, N''Yêu cầu hoàn phải thuộc đơn đã thanh toán và hoàn theo phương thức gốc.'', 1;
END;';

    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_Orders_VerifyRefund ON dbo.Orders
AFTER INSERT, UPDATE AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.OrderId = i.OrderId
        WHERE (d.Status = ''Refunded'' AND i.Status <> ''Refunded'')
            OR (d.Status = ''Paid'' AND i.Status NOT IN (''Paid'',''Refunded''))
            OR (i.Status = ''Refunded'' AND NOT EXISTS
                (SELECT 1 FROM dbo.RefundRequests AS r WITH (UPDLOCK, HOLDLOCK)
                 WHERE r.OrderId = i.OrderId AND r.Status = ''Refunded''))
    )
        THROW 51110, N''Chỉ cập nhật đơn đã hoàn sau khi ghi nhận yêu cầu hoàn đã thực chi.'', 1;
END;';

    EXEC sys.sp_executesql N'CREATE TRIGGER dbo.TR_TicketScanLogs_VerifyAdmission ON dbo.TicketScanLogs
AFTER INSERT, UPDATE AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM inserted AS i
        JOIN dbo.Tickets AS t WITH (UPDLOCK, HOLDLOCK) ON t.TicketId = i.TicketId
        WHERE i.ResultCode = ''Admitted'' AND
            (t.ShowtimeId <> i.GateShowtimeId OR t.CheckedInAtUtc IS NULL
                OR t.CheckedInByUserId <> i.EmployeeUserId OR t.CancelledAtUtc IS NOT NULL)
    )
        THROW 51111, N''Chỉ ghi qua cổng cho vé đã xác nhận tại đúng suất và đúng nhân viên.'', 1;
END;';

    COMMIT TRANSACTION;
    PRINT N'Đã tạo 22 bảng và các ràng buộc cho CinemaManagement.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;

