using apiwithdb.Models;

namespace apiwithdb.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(Guid id);
        void Add(Book book);
        void Delete(Guid id);
    }
}
