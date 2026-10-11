namespace CinemaManagement.Common.Constants
{
    public static class CheckInConstants
    {
        /// <summary>
        /// Số phút trước khi suất chiếu bắt đầu được phép mở check-in (30 phút).
        /// </summary>
        public const int OpenMinutesBeforeStart = 30;

        /// <summary>
        /// Số phút sau khi suất chiếu bắt đầu được phép tiếp tục check-in muộn (15 phút).
        /// </summary>
        public const int CloseMinutesAfterStart = 15;
    }
}