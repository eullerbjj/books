using Books.Domain.Interfaces.Commands;
using MediatR;

namespace Books.Application.UseCases.Author.Create
{
    public sealed class CreateHandler : IRequestHandler<CreateCommand>
    {
        private readonly ICommandBase<Domain.Entities.Author> _command;

        public CreateHandler(ICommandBase<Domain.Entities.Author> command)
        {
            _command = command;
        }

        public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var entity = GetEntity(request);

            _command.Insert(entity);

            await _command.SaveChangesAsync(cancellationToken);
        }

        private static Domain.Entities.Author GetEntity(CreateCommand request)
        {
            return new Domain.Entities.Author()
            {
                Name = request.Name
            };
        }
    }
}
