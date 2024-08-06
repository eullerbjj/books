using Books.Application.Exceptions;
using Books.Domain.Entities;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.UseCases.Book.Update
{
    public sealed class UpdateHandler : IRequestHandler<UpdateCommand>
    {
        private readonly ICommandBase<Domain.Entities.Book> _command;
        private readonly IQueryBase<Domain.Entities.Book> _query;
        private readonly IQueryBase<Domain.Entities.Author> _authorQuery;
        private readonly IQueryBase<Domain.Entities.Subject> _subjectQuery;
        private readonly IBookQuery _bookQuery;


        public UpdateHandler(
            ICommandBase<Domain.Entities.Book> command,
            IQueryBase<Domain.Entities.Book> query,
            IQueryBase<Domain.Entities.Author> authorQuery,
            IQueryBase<Domain.Entities.Subject> subjectQuery,
            IBookQuery bookQuery)
        {
            _command = command;
            _query = query;
            _authorQuery = authorQuery;
            _subjectQuery = subjectQuery;
            _bookQuery = bookQuery;
        }

        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _bookQuery.GetByIdAsync(request.Id);

            if (entity is null)
            {
                throw new NotFoundException();
            }

            var newAuthors = await _authorQuery.Query().Where(x => request.AuthorIds.Contains(x.Id)).ToListAsync();
            var newSubjects = await _subjectQuery.Query().Where(x => request.SubjectIds.Contains(x.Id)).ToListAsync();
            var newPrices = request.Prices
                .Select(price => new Price()
                {
                    SaleTypeId = price.SaleTypeId,
                    Value = price.Value
                }).ToList();

            entity.Authors.Clear();
            entity.Subjects.Clear();
            entity.Prices.Clear();

            entity.Title = request.Title;
            entity.Publisher = request.Publisher;
            entity.Edition = request.Edition;
            entity.PublicationYear = request.PublicationYear;
            entity.Authors = newAuthors;
            entity.Subjects = newSubjects;
            entity.Prices = newPrices;

            _command.Update(entity);

            await _command.SaveChangesAsync(cancellationToken);
        }
    }
}
