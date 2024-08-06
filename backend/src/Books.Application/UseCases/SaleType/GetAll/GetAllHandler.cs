using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.SaleType.GetAll
{
    public sealed class GetAllHandler : IRequestHandler<GetAllQuery, GetAllResult>
    {
        private readonly IQueryBase<Domain.Entities.SaleType> _query;

        public GetAllHandler(IQueryBase<Domain.Entities.SaleType> query)
        {
            _query = query;
        }

        public async Task<GetAllResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _query.GetAllAsync();
            
            return new GetAllResult(entities.Select(entity => (SaleTypeResult)entity));
        }
    }
}
