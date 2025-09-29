using apiwithdb.Models;
using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book? GetById(Guid id);
        Book Create(CreateBookDto dto);
        bool Delete(Guid id);
    }
}
