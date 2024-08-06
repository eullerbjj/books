using Books.Domain.Interfaces.Commands;

namespace Books.Persistence.Commands
{
    public sealed class BaseCommand<TEntity> : ICommandBase<TEntity> where TEntity : class
    {
        public readonly BooksDbContext _context;

        public BaseCommand(BooksDbContext context)
        {
            _context = context;
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Insert(IList<TEntity> entity)
        {
            _context.Set<TEntity>().AddRangeAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
