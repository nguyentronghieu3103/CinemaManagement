# STORYLINE CINEMA - TÀI LIỆU CƠ SỞ DỮ LIỆU NGUỒN (DATABASE SCRIPTS)
**Hệ thống Quản lý & Bán vé Rạp Chiếu Phim STORYLINE**  
*Mã nguồn CSDL SQL Server 2019/2022 - Chuẩn hóa 3NF - Tương thích EF Core 10*

---

## 1. DANH MỤC CÁC TẬP TIN SCRIPT (.SQL)

Thư mục database được module hóa chuyên nghiệp thành 9 tập tin thực thi theo thứ tự tuần tự:

| Thứ Tự | Tên Tập Tin | Mô Tả Chức Năng |
| :---: | :--- | :--- |
| **01** | [`01_create_database.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/01_create_database.sql) | Tạo CSDL `CinemaManagementDb`, cấu hình Collation `Vietnamese_CI_AS` và tham số môi trường ANSI |
| **02** | [`02_create_tables.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/02_create_tables.sql) | Tạo cấu trúc 18 bảng chuẩn hóa 3NF với Khóa chính (PK), Identity, kiểu dữ liệu chuẩn và Default Values |
| **03** | [`03_constraints.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/03_constraints.sql) | Toàn bộ Khóa ngoại (FK), Ràng buộc duy nhất (UQ) và Ràng buộc kiểm tra miền giá trị (CK) |
| **04** | [`04_indexes.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/04_indexes.sql) | Chỉ mục tối ưu hóa, Filtered Unique Index chống trùng vé và Composite Covering Indexes |
| **05** | [`05_views.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/05_views.sql) | 7 Khung nhìn (Views) hỗ trợ báo cáo doanh thu, lịch chiếu, sơ đồ ghế và cảnh báo tồn kho bắp nước |
| **06** | [`06_procedures.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/06_procedures.sql) | 6 Stored Procedures: Kiểm tra trùng lịch, thêm suất chiếu, hoàn vé, mở/kết ca và báo cáo doanh thu |
| **07** | [`07_functions.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/07_functions.sql) | Các hàm Scalar & Table-Valued tính giá vé động, hạng thẻ, sơ đồ ghế phòng chiếu và lịch sử đặt vé |
| **08** | [`08_triggers.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/08_triggers.sql) | Bộ Triggers bảo vệ lịch chiếu (+15p dọn phòng), kiểm tra ghế/phòng, trừ kho bắp nước và tích điểm |
| **09** | [`09_seed_data.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/09_seed_data.sql) | Bộ dữ liệu mẫu tiếng Việt phong phú: Tài khoản, Phim, 220 Ghế, Suất chiếu, Bắp nước, Hóa đơn mẫu |

> Ngoài ra, file [`Cinema.Setup.sql`](file:///c:/Users/Admin/OneDrive/Documents/BTL_LTTQ/CinemaManagement/database/Cinema.Setup.sql) là bản tổng hợp "All-In-One" để bạn có thể chạy một lần (F5) toàn bộ hệ thống nếu muốn.

---

## 2. HƯỚNG DẪN CÀI ĐẶT & THỰC THI (DEPLOYMENT)

### Cách 1: Thực thi tuần tự từng file trên SSMS (Khuyến nghị)
1. Mở **SQL Server Management Studio (SSMS)** hoặc **Azure Data Studio**.
2. Kết nối tới máy chủ SQL Server của bạn (ví dụ: `.` hoặc `localhost` hoặc `(localdb)\MSSQLLocalDB`).
3. Mở và nhấn **Execute (F5)** lần lượt từng file theo đúng thứ tự từ `01` đến `09`:
   - `01_create_database.sql`
   - `02_create_tables.sql`
   - `03_constraints.sql`
   - `04_indexes.sql`
   - `05_views.sql`
   - `06_procedures.sql`
   - `07_functions.sql`
   - `08_triggers.sql`
   - `09_seed_data.sql`

### Cách 2: Thực thi nhanh bằng một câu lệnh Command Prompt / PowerShell
Mở PowerShell tại thư mục này và chạy lệnh:
```powershell
Get-ChildItem -Filter "*.sql" | Sort-Object Name | ForEach-Object {
    Write-Host "Dang chay: $($_.Name)..." -ForegroundColor Cyan
    sqlcmd -S "(localdb)\MSSQLLocalDB" -i $_.FullName
}
```

---

## 3. THÔNG TIN KẾT NỐI & TÀI KHOẢN MẪU

### Connection String (appsettings.json / App.config):
```json
"ConnectionStrings": {
  "CinemaDbConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CinemaManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Tài khoản đăng nhập nội bộ (Mật khẩu đã băm SHA-256):
| Tên Đăng Nhập | Mật Khẩu | Vai Trò (Role) | Họ Và Tên |
| :--- | :--- | :--- | :--- |
| **admin** | `Admin@123` | **Admin** (Toàn quyền quản trị) | Nguyễn Quản Trị |
| **manager** | `Manager@123` | **Manager** (Quản lý rạp & lịch chiếu) | Trần Thị Quản Lý |
| **staff01** | `Staff@123` | **Staff** (Nhân viên quầy vé POS) | Lê Văn Thu Ngân |
| **staff02** | `Staff@123` | **Staff** (Nhân viên soát vé) | Phạm Thị Soát Vé |
