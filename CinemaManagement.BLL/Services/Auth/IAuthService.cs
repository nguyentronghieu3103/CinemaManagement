using CinemaManagement.Common.DTOs.Auth;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Auth
{
    public interface IAuthService
    {
        Task<Result<LoginResultDto>> LoginAsync(string email, string password);
        Task LogoutAsync(int userId);
        Task<UserProfileDto?> GetUserProfileAsync(int userId);
        Task<Result<bool>> UpdateProfileAsync(int userId, string hoTen, string sdt);
        Task<Result<bool>> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    }
}