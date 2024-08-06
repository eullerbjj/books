using MediatR;

namespace Books.Application.UseCases.Book.Delete
{
    public sealed record DeleteCommand(int Id) : IRequest { }
}
