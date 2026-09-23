namespace CinemaManagement.Common.Constants
{
    public static class SecurityConstants
    {
        public const int MaxFailedAttempts = 5;
        public const int FailedAttemptWindowMinutes = 15;
        public const int BaseLockoutMinutes = 15;   // lần khóa đầu = 15 phút, lần 2 = 30, lần 3 = 45...
    }
}