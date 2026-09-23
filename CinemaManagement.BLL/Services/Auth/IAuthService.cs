using CinemaManagement.Common.DTOs.Auth;
using CinemaManagement.Common.Results;

namespace CinemaManagement.BLL.Services.Auth
{
    public interface IAuthService
    {
        Task<Result<LoginResultDto>> LoginAsync(string email, string password);
        Task LogoutAsync(int userId);
    }
}