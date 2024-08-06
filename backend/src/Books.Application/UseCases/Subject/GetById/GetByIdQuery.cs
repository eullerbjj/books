using MediatR;

namespace Books.Application.UseCases.Subject.GetById
{
    public sealed record GetByIdQuery(int Id) : IRequest<GetByIdResult> { }
}
