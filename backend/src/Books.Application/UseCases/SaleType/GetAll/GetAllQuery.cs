using MediatR;

namespace Books.Application.UseCases.SaleType.GetAll
{
    public sealed record GetAllQuery : IRequest<GetAllResult> { }
}
