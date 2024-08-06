using MediatR;

namespace Books.Application.UseCases.Author.Create
{
    public sealed record CreateCommand(string Name) : IRequest { }
}
