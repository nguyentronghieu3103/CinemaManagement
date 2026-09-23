namespace CinemaManagement.Common.DTOs.Auth
{
    public class LoginResultDto
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new();
    }
}