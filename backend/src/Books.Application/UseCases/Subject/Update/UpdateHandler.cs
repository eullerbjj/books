using Books.Application.Exceptions;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using MediatR;

namespace Books.Application.UseCases.Subject.Update
{
    public sealed class UpdateHandler : IRequestHandler<UpdateCommand>
    {
        private readonly ICommandBase<Domain.Entities.Subject> _command;
        private readonly IQueryBase<Domain.Entities.Subject> _query;

        public UpdateHandler(
            ICommandBase<Domain.Entities.Subject> command, 
            IQueryBase<Domain.Entities.Subject> query)
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

            entity.Description = request.Description;

            _command.Update(entity);

            await _command.SaveChangesAsync(cancellationToken);
        }
    }
}
