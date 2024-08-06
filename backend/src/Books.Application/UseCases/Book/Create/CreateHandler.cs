using Books.Domain.Entities;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Book.Create
{
    public sealed class CreateHandler : IRequestHandler<CreateCommand>
    {
        private readonly ICommandBase<Domain.Entities.Book> _bookCommand;
        private readonly IQueryBase<Domain.Entities.Author> _authorQuery;
        private readonly IQueryBase<Domain.Entities.Subject> _subjectQuery;


        public CreateHandler(
            ICommandBase<Domain.Entities.Book> bookCommand,
            IQueryBase<Domain.Entities.Author> authorQuery,
            IQueryBase<Domain.Entities.Subject> subjectQuery)
        {
            _bookCommand = bookCommand;
            _authorQuery = authorQuery;
            _subjectQuery = subjectQuery;
        }

        public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var entity = GetEntity(request);
            
            LoadAdditionalData(request, entity);

            _bookCommand.Insert(entity);

            await _bookCommand.SaveChangesAsync(cancellationToken);
        }

        private void LoadAdditionalData(CreateCommand request, Domain.Entities.Book entity)
        {
            var authors = _authorQuery.Query()
                .Where(author => request.AuthorIds.Contains(author.Id)).ToList();

            var subjects = _subjectQuery.Query()
                .Where(subject => request.SubjectIds.Contains(subject.Id)).ToList();

            var prices = request.Prices
                .Select(price => new Price()
                {
                    SaleTypeId = price.SaleTypeId,
                    Value = price.Value
                }).ToList();

            entity.Authors = authors;
            entity.Subjects = subjects;
            entity.Prices = prices;
        }

        private static Domain.Entities.Book GetEntity(CreateCommand request)
        {
            return new Domain.Entities.Book()
            {
                Title = request.Title,
                Publisher = request.Publisher,
                Edition = request.Edition,
                PublicationYear = request.PublicationYear
            };
        }
    }
}
