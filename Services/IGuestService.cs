using apiwithdb.Models;
using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAll();
        Guest? GetById(Guid id);
        Guest Create(CreateGuestDto dto);
        bool Delete(Guid id);
    }
}
