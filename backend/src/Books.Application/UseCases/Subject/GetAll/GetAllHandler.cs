using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Subject.GetAll
{
    public sealed class GetAllHandler : IRequestHandler<GetAllQuery, GetAllResult>
    {
        private readonly IQueryBase<Domain.Entities.Subject> _query;

        public GetAllHandler(IQueryBase<Domain.Entities.Subject> query)
        {
            _query = query;
        }

        public async Task<GetAllResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _query.GetAllAsync();
            
            return new GetAllResult(entities.Select(entity => (SubjectResult)entity));
        }
    }
}
