
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
        private IRepository<Movie>? _movies;
        private IRepository<Genre>? _genres;
        private IRepository<CinemaRoom>? _cinemaRooms;
        private IRepository<Seat>? _seats;

        private IRepository<Showtime>? _showtimes;
        private IRepository<Customer>? _customers;
        private IRepository<Combo>? _combos;
        private IRepository<Invoice>? _invoices;
        private IRepository<Ticket>? _tickets;
        private IRepository<Payment>? _payments;
        private IRepository<EmailLog>? _emailLogs;
        private IRepository<AuditLog>? _auditLogs;
        public UnitOfWork(CinemaDbContext context) => _context = context;

        // Lazy-load: repository chỉ được tạo khi thực sự dùng tới
        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IRepository<Role> Roles => _roles ??= new Repository<Role>(_context);
        public IRepository<Permission> Permissions => _permissions ??= new Repository<Permission>(_context);
        public IRepository<Employee> Employees => _employees ??= new Repository<Employee>(_context);
        public IRepository<Movie> Movies => _movies ??= new Repository<Movie>(_context);
        public IRepository<Genre> Genres => _genres ??= new Repository<Genre>(_context);
        public IRepository<CinemaRoom> CinemaRooms => _cinemaRooms ??= new Repository<CinemaRoom>(_context);
        public IRepository<Seat> Seats => _seats ??= new Repository<Seat>(_context);

        public IRepository<Showtime> Showtimes => _showtimes ??= new Repository<Showtime>(_context);

        public IRepository<Customer> Customers => _customers ??= new Repository<Customer>(_context);
        public IRepository<Combo> Combos => _combos ??= new Repository<Combo>(_context);
        public IRepository<Invoice> Invoices => _invoices ??= new Repository<Invoice>(_context);

        public IRepository<Ticket> Tickets => _tickets ??= new Repository<Ticket>(_context);
        public IRepository<Payment> Payments => _payments ??= new Repository<Payment>(_context);

        public IRepository<EmailLog> EmailLogs => _emailLogs ??= new Repository<EmailLog>(_context);
        public IRepository<AuditLog> AuditLogs => _auditLogs ??= new Repository<AuditLog>(_context);
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