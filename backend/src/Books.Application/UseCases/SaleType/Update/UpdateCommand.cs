using MediatR;

namespace Books.Application.UseCases.SaleType.Update
{
    public sealed record UpdateCommand(int Id, string Description) : IRequest { }
}
