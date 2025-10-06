using apiwithdb.Models;
using apiwithdb.Data;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly AppDbContextGuests _gContext;
        public GuestRepository(AppDbContextGuests gContext)
        {
            _gContext = gContext;
        }
        public async Task Add(Guest guest)
        {
            await _gContext.Guests.AddAsync(guest);
        }
        public async Task Delete(Guid id)
        {
            var g = await _gContext.Guests.FirstOrDefaultAsync(x => x.Id == id);
            if (g != null)
            {
                _gContext.Guests.Remove(g);
            }
        }
        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _gContext.Guests.ToListAsync();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            return await _gContext.Guests.FirstOrDefaultAsync(x=> x.Id == id);
        }
    }
}
