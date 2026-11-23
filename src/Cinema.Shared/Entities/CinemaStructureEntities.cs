namespace Cinema.Shared.Entities;

public class Auditorium
{
    public int AuditoriumId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ScreenType { get; set; } = "2D Standard";
    public int TotalSeats { get; set; }
    public int TotalRows { get; set; }
    public int TotalColumns { get; set; }
    public string Status { get; set; } = "Active";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}

public class SeatType
{
    public int SeatTypeId { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#64748B";
    public decimal SurchargeAmount { get; set; } = 0;
    public string? Description { get; set; }

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
}

public class Seat
{
    public int SeatId { get; set; }
    public int AuditoriumId { get; set; }
    public string SeatRow { get; set; } = string.Empty;
    public int SeatNumber { get; set; }
    public string SeatCode { get; set; } = string.Empty;
    public int SeatTypeId { get; set; }
    public bool IsActive { get; set; } = true;

    public Auditorium? Auditorium { get; set; }
    public SeatType? SeatType { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

public class Showtime
{
    public int ShowtimeId { get; set; }
    public int MovieId { get; set; }
    public int AuditoriumId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal BasePrice { get; set; }
    public string Status { get; set; } = "Scheduled";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Movie? Movie { get; set; }
    public Auditorium? Auditorium { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

public class Concession
{
    public int ConcessionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = "Popcorn";
    public string Unit { get; set; } = "Hộp";
    public decimal UnitPrice { get; set; }
    public decimal CostPrice { get; set; } = 0;
    public int StockQuantity { get; set; } = 0;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<OrderConcession> OrderConcessions { get; set; } = new List<OrderConcession>();
}
