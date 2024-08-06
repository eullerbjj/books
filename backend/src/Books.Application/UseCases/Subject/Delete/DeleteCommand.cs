using MediatR;

namespace Books.Application.UseCases.Subject.Delete
{
    public sealed record DeleteCommand(int Id) : IRequest { }
}
