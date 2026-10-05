namespace CinemaManagement.Common.Constants
{
    public static class CartConstants
    {
        // DOCX M5: số lượng combo phải >= 0, không cho số âm
        public const int MinComboQuantity = 0;

        // Trần trên cho mỗi loại combo, chỉ để chặn nhập nhầm (vd. bấm giữ nút +). Đổi số này nếu nghiệp vụ cần.
        public const int MaxComboQuantity = 20;
    }
}
