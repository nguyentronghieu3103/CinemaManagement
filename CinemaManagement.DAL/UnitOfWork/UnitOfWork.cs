
using CinemaManagement.Common.Entities;
using CinemaManagement.Common.Interfaces.Repositories;
using CinemaManagement.DAL.Context;
using CinemaManagement.DAL.Repositories;
using CinemaManagement.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace CinemaManagement.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaDbContext _context;
        private IDbContextTransaction? _transaction;

        private IUserRepository? _users;
        private IRepository<Role>? _roles;
        private IRepository<Permission>? _permissions;
        private IRepository<Employee>? _employees;

        public UnitOfWork(CinemaDbContext context) => _context = context;

        // Lazy-load: repository chỉ được tạo khi thực sự dùng tới
        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IRepository<Role> Roles => _roles ??= new Repository<Role>(_context);
        public IRepository<Permission> Permissions => _permissions ??= new Repository<Permission>(_context);
        public IRepository<Employee> Employees => _employees ??= new Repository<Employee>(_context);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task BeginTransactionAsync()
            => _transaction = await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync();
            if (_transaction != null) await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null) await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}