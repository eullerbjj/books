using MediatR;

namespace Books.Application.UseCases.Author.Delete
{
    public sealed record DeleteCommand(int Id) : IRequest { }
}
