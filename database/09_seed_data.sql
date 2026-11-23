/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 09: BỘ DỮ LIỆU MẪU ĐẦY ĐỦ TIẾNG VIỆT (SEED DATA)
========================================================================================
*/

USE CinemaManagementDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

PRINT N'>> Bắt đầu nạp Dữ liệu mẫu (Seed Data)...';

-- 1. Seed Cấu hình hệ thống (SystemConfigs)
INSERT INTO dbo.SystemConfigs (ConfigKey, ConfigValue, Description) VALUES
('HOLD_SEAT_TIMEOUT_MINUTES', '10', N'Thời gian giữ ghế tạm thời khi thanh toán (phút)'),
('POINTS_CONVERSION_RATE', '0.05', N'Tỷ lệ tích điểm (5% giá trị hóa đơn quy ra điểm)'),
('POINTS_REDEMPTION_VALUE', '1000', N'1 điểm thưởng tương đương 1,000 VND giảm trừ'),
('MIN_MINUTES_BEFORE_REFUND', '60', N'Thời gian tối thiểu trước giờ chiếu để được hoàn vé (phút)'),
('CINEMA_BRAND_NAME', 'STORYLINE CINEMA', N'Tên thương hiệu rạp chiếu phim'),
('CINEMA_HOTLINE', '1900 6868', N'Tổng đài hỗ trợ khách hàng');

-- 2. Seed Vai trò (Roles)
INSERT INTO dbo.Roles (RoleName, Description) VALUES
(N'Admin', N'Quản trị viên toàn quyền hệ thống, phân quyền và cấu hình'),
(N'Manager', N'Quản lý rạp: quản lý phim, suất chiếu, phòng chiếu, bắp nước và xem báo cáo'),
(N'Staff', N'Nhân viên bán vé và soát vé tại quầy POS');

-- 3. Seed Người dùng nội bộ (Users)
-- Mật khẩu mã hóa SHA-256:
-- Admin@123   -> a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3
-- Manager@123 -> 0192023a7bbd73250516f069df18b500e8fbced026b1424e83c84f50f288d672
-- Staff@123   -> e86f78a8a3caf0b60d8e74e5942aa6d86dc1505db422e1da0259b58971f49615
INSERT INTO dbo.Users (Username, PasswordHash, FullName, Email, PhoneNumber, RoleId, IsActive) VALUES
('admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Nguyễn Quản Trị', 'admin@storyline.vn', '0901234567', 1, 1),
('manager', '0192023a7bbd73250516f069df18b500e8fbced026b1424e83c84f50f288d672', N'Trần Thị Quản Lý', 'manager@storyline.vn', '0902345678', 2, 1),
('staff01', 'e86f78a8a3caf0b60d8e74e5942aa6d86dc1505db422e1da0259b58971f49615', N'Lê Văn Thu Ngân', 'staff01@storyline.vn', '0903456789', 3, 1),
('staff02', 'e86f78a8a3caf0b60d8e74e5942aa6d86dc1505db422e1da0259b58971f49615', N'Phạm Thị Soát Vé', 'staff02@storyline.vn', '0904567890', 3, 1);

-- 4. Seed Thể loại phim (Genres)
INSERT INTO dbo.Genres (GenreName, Description) VALUES
(N'Hành động', N'Phim có nhiều pha gay cấn, rượt đuổi và chiến đấu kịch tính'),
(N'Hoạt hình', N'Phim đồ họa hoạt họa dành cho mọi lứa tuổi và gia đình'),
(N'Kinh dị', N'Phim tạo cảm giác rùng rợn, giật gân và hồi hộp'),
(N'Tình cảm - Lãng mạn', N'Phim về tình yêu, cảm xúc và các mối quan hệ con người'),
(N'Khoa học viễn tưởng', N'Phim khai thác thế giới tương lai, vũ trụ và công nghệ'),
(N'Hài kịch', N'Phim giải trí vui nhộn mang lại tiếng cười sảng khoái');

-- 5. Seed Phim (Movies)
INSERT INTO dbo.Movies (Title, EnglishTitle, Director, Cast, DurationMinutes, ReleaseDate, EndDate, AgeRating, Language, Subtitle, PosterUrl, Description, Status) VALUES
(N'Đất Rừng Phương Nam', N'Song of the South', N'Nguyễn Quang Dũng', N'Hạo Khang, Tuấn Trần, Trấn Thành, Tiến Luật, Hồng Ánh', 134, '2024-01-10', '2024-04-30', N'K', N'Tiếng Việt', N'Phụ đề Tiếng Anh', '/images/posters/dat_rung_phuong_nam.jpg', N'Hành trình tìm cha đầy xúc động của cậu bé An giữa khung cảnh hào sảng của miền Tây Nam Bộ.', N'NowShowing'),
(N'Mai', N'Mai', N'Trấn Thành', N'Phương Anh Đào, Tuấn Trần, NSND Việt Anh, Hồng Đào', 131, '2024-02-10', '2024-05-15', N'T18', N'Tiếng Việt', N'Phụ đề Tiếng Anh', '/images/posters/mai.jpg', N'Câu chuyện tình yêu đầy trắc trở giữa Mai - người phụ nữ từng chịu nhiều tổn thương và Dương - chàng nhạc công phong lưu.', N'NowShowing'),
(N'Kung Fu Panda 4', N'Kung Fu Panda 4', N'Mike Mitchell', N'Jack Black, Awkwafina, Viola Davis, Dustin Hoffman', 94, '2024-03-08', '2024-06-01', N'P', N'Tiếng Anh', N'Phụ đề Tiếng Việt & Lồng tiếng', '/images/posters/kungfu_panda_4.jpg', N'Chú gấu Po tiếp tục hành trình trở thành Thủ lĩnh Tinh thần của Thung lũng Bình Yên và đối đầu Tắc Kè Bông.', N'NowShowing'),
(N'Dune: Hành Tinh Cát - Phần 2', N'Dune: Part Two', N'Denis Villeneuve', N'Timothée Chalamet, Zendaya, Rebecca Ferguson, Javier Bardem', 166, '2024-03-01', '2024-05-30', N'T16', N'Tiếng Anh', N'Phụ đề Tiếng Việt', '/images/posters/dune_part_two.jpg', N'Paul Atreides hợp lực cùng Chani và người Fremen trên con đường báo thù những kẻ đã hủy diệt gia tộc mình.', N'NowShowing'),
(N'Godzilla x Kong: Đế Chế Mới', N'Godzilla x Kong: The New Empire', N'Adam Wingard', N'Rebecca Hall, Brian Tyree Henry, Dan Stevens', 115, '2024-03-29', '2024-06-15', N'T13', N'Tiếng Anh', N'Phụ đề Tiếng Việt', '/images/posters/godzilla_x_kong.jpg', N'Godzilla và Kong phải gạt bỏ hiềm khích để cùng hợp lực chống lại một mối đe dọa khổng lồ từ Trái Đất Rỗng.', N'NowShowing'),
(N'Lật Mặt 7: Một Điều Ước', N'Face Off 7: One Wish', N'Lý Hải', N'Thanh Hiền, Trương Minh Cường, Đinh Y Nhung, Quách Ngọc Tuyên', 138, '2024-04-26', '2024-07-30', N'K', N'Tiếng Việt', N'Phụ đề Tiếng Anh', '/images/posters/lat_mat_7.jpg', N'Câu chuyện gia đình xúc động xoay quanh người mẹ già neo đơn và tấm lòng của 5 người con trưởng thành.', N'ComingSoon');

-- 6. Seed Bảng liên kết Phim - Thể loại (MovieGenres)
INSERT INTO dbo.MovieGenres (MovieId, GenreId) VALUES
(1, 1), (1, 4),
(2, 4), (2, 6),
(3, 2), (3, 1), (3, 6),
(4, 5), (4, 1),
(5, 1), (5, 5),
(6, 4), (6, 6);

-- 7. Seed Loại ghế (SeatTypes)
INSERT INTO dbo.SeatTypes (TypeName, ColorCode, SurchargeAmount, Description) VALUES
(N'Standard', '#64748B', 0.00, N'Ghế tiêu chuẩn êm ái, vị trí xem cơ bản'),
(N'VIP', '#E11D48', 15000.00, N'Ghế trung tâm góc nhìn hoàn hảo, khoảng để chân rộng rãi'),
(N'Sweetbox', '#D946EF', 30000.00, N'Ghế đôi không vách ngăn tạo không gian riêng tư cho cặp đôi'),
(N'Accessible', '#0EA5E9', 0.00, N'Ghế lối đi ưu tiên dành cho người khuyết tật & người cao tuổi');

-- 8. Seed Phòng chiếu (Auditoriums)
INSERT INTO dbo.Auditoriums (Name, ScreenType, TotalSeats, TotalRows, TotalColumns, Status) VALUES
(N'Cinema 01 - Tiêu Chuẩn', N'2D Standard', 80, 8, 10, N'Active'),
(N'Cinema 02 - Dolby Atmos', N'3D Digital', 80, 8, 10, N'Active'),
(N'Cinema 03 - IMAX Laser', N'IMAX Laser', 60, 6, 10, N'Active');

-- 9. Tự động sinh danh sách Ghế (Seats) cho 3 phòng chiếu
DECLARE @AudId INT = 1;
WHILE @AudId <= 3
BEGIN
    DECLARE @RowIdx INT = 1;
    DECLARE @MaxRows INT = CASE WHEN @AudId = 3 THEN 6 ELSE 8 END;

    WHILE @RowIdx <= @MaxRows
    BEGIN
        DECLARE @RowChar VARCHAR(1) = CHAR(64 + @RowIdx);
        DECLARE @ColIdx INT = 1;

        WHILE @ColIdx <= 10
        BEGIN
            DECLARE @SeatCode VARCHAR(10) = @RowChar + RIGHT('0' + CAST(@ColIdx AS VARCHAR(2)), 2);
            DECLARE @TypeId INT = 1;

            IF @RowIdx IN (4, 5, 6)
                SET @TypeId = 2; -- VIP
            ELSE IF @RowIdx = @MaxRows
                SET @TypeId = 3; -- Sweetbox
            ELSE IF @RowIdx = 1 AND @ColIdx IN (1, 10)
                SET @TypeId = 4; -- Ưu tiên

            INSERT INTO dbo.Seats (AuditoriumId, SeatRow, SeatNumber, SeatCode, SeatTypeId, IsActive)
            VALUES (@AudId, @RowChar, @ColIdx, @SeatCode, @TypeId, 1);

            SET @ColIdx = @ColIdx + 1;
        END
        SET @RowIdx = @RowIdx + 1;
    END
    SET @AudId = @AudId + 1;
END;

-- 10. Seed Danh mục Bắp Nước & Combo (Concessions)
INSERT INTO dbo.Concessions (Name, Category, Unit, UnitPrice, CostPrice, StockQuantity, ImageUrl, IsActive) VALUES
(N'Bắp Rang Bơ Phô Mai (Vừa)', N'Popcorn', N'Hộp', 55000.00, 15000.00, 200, '/images/concessions/popcorn_cheese.png', 1),
(N'Bắp Rang Bơ Caramel (Lớn)', N'Popcorn', N'Hộp', 65000.00, 18000.00, 200, '/images/concessions/popcorn_caramel.png', 1),
(N'Coca-Cola Tươi 32oz', N'Beverage', N'Ly', 35000.00, 8000.00, 500, '/images/concessions/coca_cola.png', 1),
(N'Sprite Tươi 32oz', N'Beverage', N'Ly', 35000.00, 8000.00, 300, '/images/concessions/sprite.png', 1),
(N'Combo Solo (1 Bắp vừa + 1 Nước 32oz)', N'Combo', N'Combo', 79000.00, 22000.00, 150, '/images/concessions/combo_solo.png', 1),
(N'Combo Couple (1 Bắp lớn + 2 Nước 32oz)', N'Combo', N'Combo', 109000.00, 32000.00, 150, '/images/concessions/combo_couple.png', 1),
(N'Combo Gia Đình (2 Bắp lớn + 4 Nước 32oz)', N'Combo', N'Combo', 199000.00, 60000.00, 100, '/images/concessions/combo_family.png', 1),
(N'Snack Khoai Tây Lays Vị Tự Nhiên', N'Snack', N'Gói', 25000.00, 12000.00, 120, '/images/concessions/snack_lays.png', 1),
(N'Nước Khoáng Dasani 500ml', N'Beverage', N'Chai', 20000.00, 5000.00, 200, '/images/concessions/dasani.png', 1);

-- 11. Seed Khách hàng Thành viên (Memberships)
INSERT INTO dbo.Memberships (CardNumber, CustomerName, PhoneNumber, Email, Birthday, Points, TierLevel, TotalSpent, IsActive) VALUES
('MB20240001', N'Trần Minh Hoàng', '0912345678', 'hoang.tran@gmail.com', '1998-05-14', 120, N'Gold', 3450000.00, 1),
('MB20240002', N'Nguyễn Quỳnh Như', '0987654321', 'quynhnhu.ng@yahoo.com', '2001-11-20', 45, N'Silver', 1250000.00, 1),
('MB20240003', N'Lê Quốc Bảo', '0933221100', 'baole99@gmail.com', '1995-08-02', 250, N'Platinum', 6800000.00, 1),
('MB20240004', N'Phạm Thảo Vy', '0944556677', 'thaovy.pham@outlook.com', '2003-02-18', 10, N'Standard', 280000.00, 1);

-- 12. Seed Suất chiếu mẫu (Showtimes)
DECLARE @Today DATE = CAST(GETDATE() AS DATE);

INSERT INTO dbo.Showtimes (MovieId, AuditoriumId, StartTime, EndTime, BasePrice, Status) VALUES
-- Suất chiếu Phim Mai (Cinema 01)
(2, 1, DATEADD(HOUR, 9, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 9*60 + 131, CAST(@Today AS DATETIME2(0))), 85000.00, N'Finished'),
(2, 1, DATEADD(HOUR, 13, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 13*60 + 131, CAST(@Today AS DATETIME2(0))), 90000.00, N'Scheduled'),
(2, 1, DATEADD(HOUR, 18, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 18*60 + 131, CAST(@Today AS DATETIME2(0))), 95000.00, N'Scheduled'),

-- Suất chiếu Kung Fu Panda 4 (Cinema 02 - Dolby Atmos)
(3, 2, DATEADD(HOUR, 10, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 10*60 + 94, CAST(@Today AS DATETIME2(0))), 85000.00, N'Scheduled'),
(3, 2, DATEADD(HOUR, 14, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 14*60 + 94, CAST(@Today AS DATETIME2(0))), 90000.00, N'Scheduled'),
(3, 2, DATEADD(HOUR, 19, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 19*60 + 94, CAST(@Today AS DATETIME2(0))), 95000.00, N'Scheduled'),

-- Suất chiếu Dune: Part Two (Cinema 03 - IMAX Laser)
(4, 3, DATEADD(HOUR, 11, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 11*60 + 166, CAST(@Today AS DATETIME2(0))), 130000.00, N'Scheduled'),
(4, 3, DATEADD(HOUR, 16, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 16*60 + 166, CAST(@Today AS DATETIME2(0))), 140000.00, N'Scheduled'),
(4, 3, DATEADD(HOUR, 20, CAST(@Today AS DATETIME2(0))), DATEADD(MINUTE, 20*60 + 166, CAST(@Today AS DATETIME2(0))), 150000.00, N'Scheduled');

-- 13. Seed Ca làm việc mẫu (Shifts)
INSERT INTO dbo.Shifts (UserId, ShiftName, StartTime, EndTime, InitialCash, FinalCash, TotalSales, Status, Notes) VALUES
(3, N'Ca Sáng (08:00 - 16:00)', DATEADD(HOUR, 8, CAST(@Today AS DATETIME2(0))), NULL, 1000000.00, NULL, 580000.00, 'OPEN', N'Bàn giao đầu ngày đủ 1,000,000đ tiền thối');

-- 14. Seed Đơn hàng & Vé mẫu (Sample Orders & Tickets)
INSERT INTO dbo.Orders (OrderCode, MembershipId, StaffUserId, OrderDate, SubTotal, DiscountAmount, FinalAmount, PaymentMethod, PaymentStatus, PointsEarned, PointsRedeemed, Notes)
VALUES ('ORD20240410001', 1, 3, DATEADD(MINUTE, -120, GETDATE()), 419000.00, 20000.00, 399000.00, 'VNPay', 'PAID', 20, 20, N'Khách quét mã VNPay-QR tại quầy');

DECLARE @SampleOrderId1 INT = SCOPE_IDENTITY();

DECLARE @SeatD05 INT = (SELECT SeatId FROM dbo.Seats WHERE AuditoriumId = 3 AND SeatCode = 'D05');
DECLARE @SeatD06 INT = (SELECT SeatId FROM dbo.Seats WHERE AuditoriumId = 3 AND SeatCode = 'D06');

INSERT INTO dbo.Tickets (OrderId, ShowtimeId, SeatId, TicketPrice, Barcode, Status) VALUES
(@SampleOrderId1, 8, @SeatD05, 155000.00, 'TK20240410001D05', 'ISSUED'),
(@SampleOrderId1, 8, @SeatD06, 155000.00, 'TK20240410001D06', 'ISSUED');

INSERT INTO dbo.OrderConcessions (OrderId, ConcessionId, Quantity, UnitPrice, TotalPrice) VALUES
(@SampleOrderId1, 6, 1, 109000.00, 109000.00);

-- Đơn hàng 2:
INSERT INTO dbo.Orders (OrderCode, MembershipId, StaffUserId, OrderDate, SubTotal, DiscountAmount, FinalAmount, PaymentMethod, PaymentStatus, PointsEarned, PointsRedeemed, Notes)
VALUES ('ORD20240410002', NULL, 3, DATEADD(MINUTE, -60, GETDATE()), 145000.00, 0.00, 145000.00, 'CASH', 'PAID', 0, 0, N'Khách thanh toán tiền mặt');

DECLARE @SampleOrderId2 INT = SCOPE_IDENTITY();

DECLARE @SeatB05 INT = (SELECT SeatId FROM dbo.Seats WHERE AuditoriumId = 1 AND SeatCode = 'B05');

INSERT INTO dbo.Tickets (OrderId, ShowtimeId, SeatId, TicketPrice, Barcode, Status) VALUES
(@SampleOrderId2, 2, @SeatB05, 90000.00, 'TK20240410002B05', 'ISSUED');

INSERT INTO dbo.OrderConcessions (OrderId, ConcessionId, Quantity, UnitPrice, TotalPrice) VALUES
(@SampleOrderId2, 1, 1, 55000.00, 55000.00);

PRINT N'>> [09_seed_data.sql] Nạp Dữ liệu mẫu (Seed Data) thành công 100%!';
GO
