using apiwithdb.Models;
using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(Guid id);
        Task<Ticket> Create(CreateTicketDto dto);
        Task<bool> Delete(Guid id);
    }
}
