using apiwithdb.Data;
using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace apiwithdb.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContextTickets _context;

        public TicketRepository(AppDbContextTickets context)
        {
            _context = context;
        }

        public async Task Add(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task Delete(Guid id)
        {
            var t = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (t != null)
            {
                _context.Tickets.Remove(t);
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
