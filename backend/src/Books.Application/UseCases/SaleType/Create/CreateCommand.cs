using MediatR;

namespace Books.Application.UseCases.SaleType.Create
{
    public sealed record CreateCommand(string Description) : IRequest { }
}
