using Books.Application.Exceptions;
using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Subject.GetById
{
    public sealed class GetByIdHandler : IRequestHandler<GetByIdQuery, GetByIdResult>
    {
        private readonly IQueryBase<Domain.Entities.Subject> _query;

        public GetByIdHandler(IQueryBase<Domain.Entities.Subject> query)
        {
            _query = query;
        }

        public async Task<GetByIdResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _query.GetByIdAsync(request.Id);

            if (entity is null)
            {
                throw new NotFoundException();
            }

            return (GetByIdResult)entity;
        }
    }
}
