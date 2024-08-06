using Books.Application.Exceptions;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Author.Update
{
    public sealed class UpdateHandler : IRequestHandler<UpdateCommand>
    {
        private readonly ICommandBase<Domain.Entities.Author> _command;
        private readonly IQueryBase<Domain.Entities.Author> _query;

        public UpdateHandler(
            ICommandBase<Domain.Entities.Author> command, 
            IQueryBase<Domain.Entities.Author> query)
        {
            _command = command;
            _query = query;
        }

        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _query.GetByIdAsync(request.Id);

            if (entity is null)
            {
                throw new NotFoundException();
            }

            entity.Name = request.Name;

            _command.Update(entity);

            await _command.SaveChangesAsync(cancellationToken);
        }
    }
}
