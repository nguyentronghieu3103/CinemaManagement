
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.DAL.Context;
using CinemaManagement.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CinemaDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
            => await _dbSet.Include(u => u.Role)   
                            .FirstOrDefaultAsync(u => u.Email == email);
    }
}