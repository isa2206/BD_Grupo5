using apiwithdb.Models;

namespace apiwithdb.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book { Id = Guid.NewGuid(), Title = "Clean Code", Year = 2008 },
            new Book { Id = Guid.NewGuid(), Title = "Pragmatic Programmer", Year = 1999 },
            new Book { Id = Guid.NewGuid(), Title = "Refactoring", Year = 1999 }
        };


        public void Add(Book book)
        {
           _books.Add(book);
        }

        public void Delete(Guid id)
        {
           _books.RemoveAll(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
           return _books;
        }

        public Book? GetById(Guid id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }
    }
}
