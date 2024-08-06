using Books.Domain.Entities;

namespace Books.Domain.Interfaces.Queries
{
    public interface IBookQuery
    {
        Task<Book?> GetByIdAsync(int id);
    }
}
