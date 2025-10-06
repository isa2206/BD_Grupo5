using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _rep;
        public GuestService(IGuestRepository rep)
        {
            _rep = rep;
        }
        public async Task<Guest> Create(CreateGuestDto dto)
        {
            var g = new Guest
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName.Trim(),
                Confirmed = dto.Confirmed
            };
            await _rep.Add(g);
            return g;
        }

        public async Task<bool> Delete(Guid id)
        {
            var g = _rep.GetById(id);
            if (g == null) return false;
            await _rep.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _rep.GetAll();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            var g = _rep.GetById(id);
            return await g;
        }
    }
}
