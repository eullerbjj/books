using Books.Domain.Entities;

namespace Books.Domain.Interfaces.Commands
{
    public interface IBookCommand : ICommandBase<Book>
    {
    }
}
