using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Enums;

namespace CinemaManagement.Common.Entities
{
    public class Seat
    {
        public int Id { get; set; }

        public int CinemaRoomId { get; set; }
        public CinemaRoom CinemaRoom { get; set; } = null!;

        public int Hang { get; set; }     
        public int Cot { get; set; }      
        public SeatType LoaiGhe { get; set; } = SeatType.Thuong;
    }
}