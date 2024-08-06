using MediatR;

namespace Books.Application.UseCases.SaleType.GetById
{
    public sealed record GetByIdQuery(int Id) : IRequest<GetByIdResult> { }
}
