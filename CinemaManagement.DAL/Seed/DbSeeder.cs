using CinemaManagement.DAL.Context;

namespace CinemaManagement.DAL.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(CinemaDbContext context)
        {
            await RoleSeeder.SeedAsync(context);
            await PermissionSeeder.SeedAsync(context);
            await UserSeeder.SeedAsync(context);
            await DemoDataSeeder.SeedAsync(context);
        }
    }
}