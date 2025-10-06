using apiwithdb.Models;
using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task<Event> Create(CreateEventDto dto);
        Task<bool> Delete(Guid id);
    }
}
