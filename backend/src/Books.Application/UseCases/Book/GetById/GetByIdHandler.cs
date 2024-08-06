using Books.Application.Exceptions;
using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Book.GetById
{
    public sealed class GetByIdHandler : IRequestHandler<GetByIdQuery, GetByIdResult>
    {
        private readonly IBookQuery _bookQuery;

        public GetByIdHandler(
            IBookQuery bookQuery)
        {
            _bookQuery = bookQuery;
        }

        public async Task<GetByIdResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _bookQuery.GetByIdAsync(request.Id);

            if (entity is null)
            {
                throw new NotFoundException();
            }

            return (GetByIdResult)entity;
        }
    }
}
