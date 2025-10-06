using System.Threading.Tasks;
using apiwithdb.Data;
using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Repositories
{
    public class EventRepository : IEventRepository
    {
        private AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Event _event)
        {
            await _context._events.AddAsync(_event);
        }

        public async Task Delete(Guid id)
        {
            var _event = await _context._events.FirstOrDefaultAsync(x => x.Id == id);
            if (_event != null)
            {
                _context._events.Remove(_event);
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context._events.ToListAsync();
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _context._events.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
