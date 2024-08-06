using Books.Domain.Entities;
using Books.Domain.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence.Queries
{
    public sealed class BookQuery : IBookQuery
    {
        public readonly BooksDbContext _context;

        public BookQuery(BooksDbContext context)
        {
            _context = context;
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            return _context.Book
                .Include(b => b.Subjects)
                .Include(b => b.Authors)
                .Include(b => b.Prices)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
