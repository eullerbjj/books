using MediatR;

namespace Books.Application.UseCases.Book.Create
{
    public sealed record CreateCommand(
        string Title, 
        string Publisher, 
        int Edition, 
        int PublicationYear,
        IList<int> SubjectIds,
        IList<int> AuthorIds,
        IList<Domain.Entities.Price> Prices) : IRequest { }
}
