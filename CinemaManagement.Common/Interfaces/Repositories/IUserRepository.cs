
using CinemaManagement.Common.Entities;

namespace CinemaManagement.Common.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}