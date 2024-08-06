using MediatR;

namespace Books.Application.UseCases.Author.GetById
{
    public sealed record GetByIdQuery(int Id) : IRequest<GetByIdResult> { }
}
