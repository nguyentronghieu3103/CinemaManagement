using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.DTOs.Sales
{
    // 1 ghế trong sơ đồ của 1 suất chiếu
    public class SeatDto
    {
        public int SeatId { get; set; }
        public int Hang { get; set; }
        public int Cot { get; set; }
        public string Label { get; set; } = string.Empty;    // "A01"
        public SeatType LoaiGhe { get; set; }
        public decimal Gia { get; set; }                      // GiaVeCoSo + phụ thu theo loại ghế (từ database)
        public SeatStatus Status { get; set; }                // Trong / DangGiu / DaDat (đã xét hết hạn giữ)
        public bool IsHeldByMe { get; set; }                  // DangGiu bởi chính phiên đang xem
    }
}
