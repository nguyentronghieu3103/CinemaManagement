
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaManagement.DAL.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CinemaDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(CinemaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Remove(T entity) => _dbSet.Remove(entity);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);
    }
}