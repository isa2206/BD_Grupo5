using apiwithdb.Models;

namespace apiwithdb.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task Add(Event book);
        Task Delete(Guid id);
    }
}
