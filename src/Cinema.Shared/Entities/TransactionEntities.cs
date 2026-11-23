namespace Cinema.Shared.Entities;

public class Order
{
    public int OrderId { get; set; }
    public string OrderCode { get; set; } = string.Empty;
    public int? MembershipId { get; set; }
    public int? StaffUserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; } = 0;
    public decimal FinalAmount { get; set; }
    public string PaymentMethod { get; set; } = "CASH";
    public string PaymentStatus { get; set; } = "PAID";
    public int PointsEarned { get; set; } = 0;
    public int PointsRedeemed { get; set; } = 0;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Membership? Membership { get; set; }
    public User? StaffUser { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public ICollection<OrderConcession> OrderConcessions { get; set; } = new List<OrderConcession>();
    public ICollection<RefundRequest> RefundRequests { get; set; } = new List<RefundRequest>();
}

public class Ticket
{
    public int TicketId { get; set; }
    public int OrderId { get; set; }
    public int ShowtimeId { get; set; }
    public int SeatId { get; set; }
    public decimal TicketPrice { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public string Status { get; set; } = "ISSUED";
    public DateTime? CheckinTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Order? Order { get; set; }
    public Showtime? Showtime { get; set; }
    public Seat? Seat { get; set; }
    public ICollection<RefundRequest> RefundRequests { get; set; } = new List<RefundRequest>();
}

public class OrderConcession
{
    public int OrderConcessionId { get; set; }
    public int OrderId { get; set; }
    public int ConcessionId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

    public Order? Order { get; set; }
    public Concession? Concession { get; set; }
}

public class Shift
{
    public int ShiftId { get; set; }
    public int UserId { get; set; }
    public string ShiftName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    public DateTime? EndTime { get; set; }
    public decimal InitialCash { get; set; } = 0;
    public decimal? FinalCash { get; set; }
    public decimal TotalSales { get; set; } = 0;
    public decimal? CashDifference { get; set; }
    public string Status { get; set; } = "OPEN";
    public string? Notes { get; set; }

    public User? User { get; set; }
}

public class RefundRequest
{
    public int RefundId { get; set; }
    public int OrderId { get; set; }
    public int TicketId { get; set; }
    public string RefundReason { get; set; } = string.Empty;
    public decimal RefundAmount { get; set; }
    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    public int? ProcessedByUserId { get; set; }
    public string Status { get; set; } = "APPROVED";
    public string? Notes { get; set; }

    public Order? Order { get; set; }
    public Ticket? Ticket { get; set; }
    public User? ProcessedByUser { get; set; }
}

public class AuditLog
{
    public long LogId { get; set; }
    public int? UserId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public string? RecordId { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string? IpAddress { get; set; }
}
