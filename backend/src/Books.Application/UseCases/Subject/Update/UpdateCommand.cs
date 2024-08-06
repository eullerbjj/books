using MediatR;

namespace Books.Application.UseCases.Subject.Update
{
    public sealed record UpdateCommand(int Id, string Description) : IRequest { }
}
