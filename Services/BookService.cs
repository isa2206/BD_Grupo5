using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }
        public Book Create(CreateBookDto dto)
        {
            if(dto.Year<1900)
            {
                throw new InvalidOperationException("Year must be between 1900 and the current year.");
            }
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Year = dto.Year
            };
            _repo.Add(book);
            return book;
        }

        public bool Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            _repo.Delete(id);
            return true;
        }

        public IEnumerable<Book> GetAll()
        {
            return _repo.GetAll();
        }

        public Book? GetById(Guid id)
        {
            var book = _repo.GetById(id);
            return book;
        }
    }
}
