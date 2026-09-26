using CinemaManagement.Common.DTOs.Dashboard;

namespace CinemaManagement.BLL.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<StaffDashboardDto> GetStaffDashboardAsync();
    }
}