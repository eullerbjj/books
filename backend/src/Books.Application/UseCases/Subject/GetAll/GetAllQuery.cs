using MediatR;

namespace Books.Application.UseCases.Subject.GetAll
{
    public sealed record GetAllQuery : IRequest<GetAllResult> { }
}
