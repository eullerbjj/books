using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Book.GetAll
{
    public sealed class GetAllHandler : IRequestHandler<GetAllQuery, GetAllResult>
    {
        private readonly IQueryBase<Domain.Entities.Book> _query;

        public GetAllHandler(IQueryBase<Domain.Entities.Book> query)
        {
            _query = query;
        }

        public async Task<GetAllResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _query.GetAllAsync();
            
            return new GetAllResult(entities.Select(entity => (BookResult)entity));
        }
    }
}
