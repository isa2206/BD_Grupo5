using System.Threading.Tasks;
using apiwithdb.Data;
using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {
            await _context.books.AddAsync(book);
        }

        public async Task Delete(Guid id)
        {
            var book = await _context.books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                _context.books.Remove(book);
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.books.ToListAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
            return await _context.books.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
