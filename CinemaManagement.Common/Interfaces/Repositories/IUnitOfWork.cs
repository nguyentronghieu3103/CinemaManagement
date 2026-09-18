using CinemaManagement.Common.Entities;

namespace CinemaManagement.Common.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Permission> Permissions { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Movie> Movies { get; }
        IRepository<Genre> Genres { get; }
        IRepository<CinemaRoom> CinemaRooms { get; }
        IRepository<Seat> Seats { get; }
        IRepository<Showtime> Showtimes { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Combo> Combos { get; }
        IRepository<Invoice> Invoices { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<EmailLog> EmailLogs { get; }
        IRepository<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}