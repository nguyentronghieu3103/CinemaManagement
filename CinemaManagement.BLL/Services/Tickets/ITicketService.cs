using CinemaManagement.Common.DTOs.Tickets;
using CinemaManagement.Common.Enums;
using CinemaManagement.Common.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaManagement.BLL.Services.Tickets
{
    public interface ITicketService
    {
        Task<Result<List<TicketDetailDto>>> SearchTicketsAsync(string query);
        Task<Result<List<TicketDetailDto>>> GetTicketsAsync(TicketFilterMode mode, string? query = null);
    }
}

