using CinemaManagement.Common.DTOs.Tickets;
using CinemaManagement.Common.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaManagement.BLL.Services.Tickets
{
    public interface ITicketService
    {
        Task<Result<List<TicketDetailDto>>> SearchTicketsAsync(string query);
    }
}
