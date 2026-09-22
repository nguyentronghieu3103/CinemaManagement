namespace CinemaManagement.Common.Constants
{
    public static class PermissionConstants
    {
        // Nghiệp vụ cơ bản — Nhân viên bán vé trở lên
        public const string TICKET_SELL = "TICKET_SELL";
        public const string CHECKIN = "CHECKIN";
        public const string CUSTOMER_CREATE = "CUSTOMER_CREATE";

        // Quản lý nghiệp vụ — Quản lý trở lên
        public const string MOVIE_MANAGE = "MOVIE_MANAGE";
        public const string ROOM_MANAGE = "ROOM_MANAGE";
        public const string SHOWTIME_MANAGE = "SHOWTIME_MANAGE";
        public const string COMBO_MANAGE = "COMBO_MANAGE";
        public const string REPORT_VIEW = "REPORT_VIEW";
        public const string IMPORT_MOVIE = "IMPORT_MOVIE";
        public const string EMPLOYEE_VIEW_PERFORMANCE = "EMPLOYEE_VIEW_PERFORMANCE";
        public const string STAFF_ACCOUNT_MANAGE = "STAFF_ACCOUNT_MANAGE";

        // Quản trị hệ thống — chỉ Quản trị viên
        public const string USER_MANAGE_ALL = "USER_MANAGE_ALL";
        public const string CONFIG_MANAGE = "CONFIG_MANAGE";
        public const string AUDITLOG_VIEW = "AUDITLOG_VIEW";
    }
}