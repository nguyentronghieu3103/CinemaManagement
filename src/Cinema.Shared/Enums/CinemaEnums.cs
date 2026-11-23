namespace Cinema.Shared.Enums;

public enum MovieStatus
{
    ComingSoon,
    NowShowing,
    EndOfShowing
}

public enum AgeRating
{
    P,   // Mọi lứa tuổi
    K,   // Dưới 13 tuổi có người giám hộ
    T13, // Từ 13 tuổi trở lên
    T16, // Từ 16 tuổi trở lên
    T18, // Từ 18 tuổi trở lên
    C    // Cấm phổ biến
}

public enum ShowtimeStatus
{
    Scheduled,
    Showing,
    Finished,
    Cancelled
}

public enum TicketStatus
{
    ISSUED,
    USED,
    REFUNDED,
    CANCELLED
}

public enum PaymentStatus
{
    PENDING,
    PAID,
    REFUNDED,
    FAILED
}

public enum MembershipTier
{
    Standard,
    Silver,
    Gold,
    Platinum
}

public enum ShiftStatus
{
    OPEN,
    CLOSED
}

public enum RefundStatus
{
    PENDING,
    APPROVED,
    REJECTED
}
