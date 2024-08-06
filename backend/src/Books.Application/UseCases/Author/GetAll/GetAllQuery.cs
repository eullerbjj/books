using MediatR;

namespace Books.Application.UseCases.Author.GetAll
{
    public sealed record GetAllQuery : IRequest<GetAllResult> { }
}
