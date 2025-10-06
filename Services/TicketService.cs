using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _rep;

        public TicketService(ITicketRepository rep)
        {
            _rep = rep;
        }

        public async Task<Ticket> Create(CreateTicketDto dto)
        {
            var ticket = new Ticket(
                Id: Guid.NewGuid(),
                Notes: dto.Notes
            );

            await _rep.Add(ticket);
            return ticket;
        }

        public async Task<bool> Delete(Guid id)
        {
            var ticket = await _rep.GetById(id);
            if (ticket == null) return false;

            await _rep.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _rep.GetAll();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            return await _rep.GetById(id);
        }
    }
}
