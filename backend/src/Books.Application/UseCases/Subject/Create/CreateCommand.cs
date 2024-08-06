using MediatR;

namespace Books.Application.UseCases.Subject.Create
{
    public sealed record CreateCommand(string Description) : IRequest { }
}
