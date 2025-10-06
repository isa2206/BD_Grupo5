using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;
        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }
        public async Task<Event> Create(CreateEventDto dto)
        {
            if (dto.Capacity < 1 || dto.Capacity > 1000)
            {
                throw new InvalidOperationException("Capacity must be between 1 and 1000.");
            }
            var _event = new Event
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Date = DateTime.Now,
                Capacity = dto.Capacity
            };
            await _repo.Add(_event);
            return _event;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Event?> GetById(Guid id)
        {
            var _event = _repo.GetById(id);
            return await _event;
        }
    }
}
