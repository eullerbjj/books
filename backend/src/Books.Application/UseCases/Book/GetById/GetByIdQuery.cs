using MediatR;

namespace Books.Application.UseCases.Book.GetById
{
    public sealed record GetByIdQuery(int Id) : IRequest<GetByIdResult> { }
}
