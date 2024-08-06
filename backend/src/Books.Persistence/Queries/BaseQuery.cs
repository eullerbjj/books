using Books.Domain.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence.Queries
{
    public sealed class BaseQuery<TEntity> : IQueryBase<TEntity> where TEntity : class, new()
    {
        public readonly BooksDbContext _context;

        public BaseQuery(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {            
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }
    }
}
