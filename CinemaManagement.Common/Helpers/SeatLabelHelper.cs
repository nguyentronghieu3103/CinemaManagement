namespace CinemaManagement.Common.Helpers
{
    public static class SeatLabelHelper
    {
        public static string Format(int hang, int cot) => $"{(char)('A' + hang - 1)}{cot:D2}";
    }
}