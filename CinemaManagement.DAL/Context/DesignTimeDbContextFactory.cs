using CinemaManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CinemaApp.DAL.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CinemaDbContext>
    {
        public CinemaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaDbContext>();
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=CinemaManagement;Username=postgres;Password=Hieu2006#");
            return new CinemaDbContext(optionsBuilder.Options);
        }
    }
}