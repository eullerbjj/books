using MediatR;

namespace Books.Application.UseCases.Book.GetAll
{
    public sealed record GetAllQuery : IRequest<GetAllResult> { }
}
