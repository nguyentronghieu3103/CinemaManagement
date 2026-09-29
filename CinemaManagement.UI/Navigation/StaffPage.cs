namespace CinemaManagement.UI.Navigation
{
    public enum StaffPage { Home, Booking, CheckIn, Lookup, SignOut }

    // Form con cho biết "sau khi đóng tôi, Dashboard nên mở trang nào"
    public interface IStaffPage
    {
        StaffPage NextPage { get; }
    }
}