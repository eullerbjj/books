using MediatR;

namespace Books.Application.UseCases.Author.Update
{
    public sealed record UpdateCommand(int Id, string Name) : IRequest { }
}
