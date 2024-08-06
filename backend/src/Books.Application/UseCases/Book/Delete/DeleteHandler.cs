using Books.Application.Exceptions;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Book.Delete
{
    public sealed class DeleteHandler : IRequestHandler<DeleteCommand>
    {
        private readonly ICommandBase<Domain.Entities.Book> _command;
        private readonly IQueryBase<Domain.Entities.Book> _query;

        public DeleteHandler(
            ICommandBase<Domain.Entities.Book> command, 
            IQueryBase<Domain.Entities.Book> query)
        {
            _command = command;
            _query = query;
        }

        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _query.GetByIdAsync(request.Id);

            if (entity is null) 
            {
                throw new NotFoundException();
            }

            _command.Delete(entity);

            await _command.SaveChangesAsync(cancellationToken);
        }
    }
}
