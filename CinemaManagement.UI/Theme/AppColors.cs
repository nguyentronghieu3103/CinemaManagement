namespace CinemaManagement.UI.Theme
{
    /// <summary>
    /// Bảng màu PREMIUM DARK CINEMA – phiên bản "Noir &amp; Champagne":
    /// nền đen ám tím than (warm noir) + đỏ rượu vang (burgundy) làm màu chủ đạo +
    /// vàng champagne làm điểm nhấn sang trọng; mọi màu đều được giảm bão hòa để dịu mắt, không "chọi" nhau.
    /// Giữ nguyên các tên cũ (TextDark, PageBackground...) để code các màn khác không phải đổi;
    /// riêng "TextDark" nay là màu CHỮ CHÍNH (sáng) vì nền đã chuyển sang tối.
    /// </summary>
    public static class AppColors
    {
        private static Color H(string hex) => ColorTranslator.FromHtml(hex);

        // ===== Nền =====
        public static readonly Color PageBackground = H("#08070B");
        public static readonly Color Background2 = H("#0C0A10");
        public static readonly Color CardBackground = H("#17131D");
        public static readonly Color Surface2 = H("#1F1A27");
        public static readonly Color InputBackground = H("#0E0C12");
        public static readonly Color HeaderBackground = H("#0C0A10");
        public static readonly Color HeaderDark = H("#08070B");
        public static readonly Color HeaderMid = H("#15111B");

        // ===== Viền =====
        public static readonly Color Border = H("#322C38");
        public static readonly Color BorderStrong = H("#443C4D");

        // ===== Đỏ rượu vang (màu chủ đạo / CTA) =====
        public static readonly Color Primary = H("#A3202A");
        public static readonly Color PrimaryHover = H("#BA3039");
        public static readonly Color PrimaryPressed = H("#701519");
        public static readonly Color DarkRed = H("#701519");
        public static readonly Color PrimarySoft = H("#2A1112");      // nền đỏ rượu rất tối (huy hiệu, icon)
        public static readonly Color Accent = H("#E0BE74");           // chữ nhấn: vàng champagne

        // ===== Vàng đồng / Xanh thông tin / Tím (giảm bão hòa, hợp tông với nền) =====
        public static readonly Color Blue = H("#6E5431");              // (tên cũ "Blue") nay là vàng đồng: dùng cho vệt sáng nền, thanh màn hình, hover
        public static readonly Color SoftBlue = H("#7787A0");
        public static readonly Color Info = H("#7787A0");
        public static readonly Color InfoSoft = H("#151922");
        public static readonly Color Purple = H("#5F4B6B");
        public static readonly Color PurpleSoft = H("#1B1722");

        // ===== Chữ (ngà ấm thay cho trắng lạnh) =====
        public static readonly Color TextDark = H("#F4F0E8");         // chữ chính (tên cũ, giá trị sáng)
        public static readonly Color TextPrimary = H("#F4F0E8");
        public static readonly Color TextSecondary = H("#D3CCC1");
        public static readonly Color TextMuted = H("#A59FA9");

        // ===== Trạng thái =====
        public static readonly Color Success = H("#58A07F");
        public static readonly Color SuccessSoft = H("#101C17");
        public static readonly Color SuccessStrong = H("#276A50");    // nút xanh lá chữ trắng (đủ tương phản)
        public static readonly Color Warning = H("#D4A55A");
        public static readonly Color StatusOrange = H("#D4A55A");     // chỉ dùng cho cảnh báo "gần đầy"
        public static readonly Color WarnSoft = H("#221C13");
        public static readonly Color Danger = H("#E0675F");
        public static readonly Color StatusRed = H("#E0675F");
        public static readonly Color DangerSoft = H("#271412");

        // ===== Bảng dữ liệu =====
        public static readonly Color RowAlt = H("#0F0D14");
        public static readonly Color RowSelected = H("#3A1718");      // đỏ rượu tối

        // ===== Ghế =====
        public static readonly Color SeatAvailable = H("#1B1722");        // trống: xám than ám tím
        public static readonly Color SeatAvailableBorder = H("#38303F");
        public static readonly Color SeatVipFill = H("#2A2316");          // VIP: nền nâu vàng tối + viền vàng champagne
        public static readonly Color SeatVipBorder = H("#CDAA62");
        public static readonly Color SeatCoupleFill = H("#2E1618");       // ghế đôi: nền đỏ rượu tối + viền hồng
        public static readonly Color SeatCoupleBorder = H("#CF5B58");
        public static readonly Color SeatSold = H("#110F15");             // đã bán: xám đen, chìm hẳn
        public static readonly Color SeatSoldBorder = H("#211D27");
        public static readonly Color SeatHolding = H("#65557A");          // bạn đang giữ: tím mận
        public static readonly Color SeatHoldOther = H("#241E2B");        // người khác giữ: tím tối
    }
}
