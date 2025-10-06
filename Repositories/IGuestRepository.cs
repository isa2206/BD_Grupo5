using apiwithdb.Models;
namespace apiwithdb.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task Add (Guest guest);
        Task Delete(Guid id);
    }
}
