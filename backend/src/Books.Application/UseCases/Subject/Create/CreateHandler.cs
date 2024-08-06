using Books.Domain.Interfaces.Commands;
using MediatR;

namespace Books.Application.UseCases.Subject.Create
{
    public sealed class CreateHandler : IRequestHandler<CreateCommand>
    {
        private readonly ICommandBase<Domain.Entities.Subject> _command;

        public CreateHandler(ICommandBase<Domain.Entities.Subject> command)
        {
            _command = command;
        }

        public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var entity = GetEntity(request);

            _command.Insert(entity);

            await _command.SaveChangesAsync(cancellationToken);
        }

        private static Domain.Entities.Subject GetEntity(CreateCommand request)
        {
            return new Domain.Entities.Subject()
            {
                Description = request.Description
            };
        }
    }
}
