using MediatR;

namespace Books.Application.UseCases.Book.Update
{
    public sealed record UpdateCommand(
        int Id,
        string Title,
        string Publisher,
        int Edition,
        int PublicationYear,
        IList<int> SubjectIds,
        IList<int> AuthorIds,
        IList<Domain.Entities.Price> Prices) : IRequest
    { }
}
