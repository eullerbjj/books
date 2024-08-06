namespace Books.Domain.Interfaces.Commands
{
    public interface ICommandBase<TEntity>
    {
        void Insert(TEntity entity);
        void Insert(IList<TEntity> entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
