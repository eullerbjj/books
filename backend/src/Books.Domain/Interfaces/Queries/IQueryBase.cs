namespace Books.Domain.Interfaces.Queries
{
    public interface IQueryBase<TEntity>
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Query();
    }
}
