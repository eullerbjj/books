using MediatR;

namespace Books.Application.UseCases.SaleType.Delete
{
    public sealed record DeleteCommand(int Id) : IRequest { }
}
