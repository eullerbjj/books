using Books.Domain.Interfaces.Commands;
using MediatR;

namespace Books.Application.UseCases.SaleType.Create
{
    public sealed class CreateHandler : IRequestHandler<CreateCommand>
    {
        private readonly ICommandBase<Domain.Entities.SaleType> _command;

        public CreateHandler(ICommandBase<Domain.Entities.SaleType> command)
        {
            _command = command;
        }

        public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var entity = GetEntity(request);

            _command.Insert(entity);

            await _command.SaveChangesAsync(cancellationToken);
        }

        private static Domain.Entities.SaleType GetEntity(CreateCommand request)
        {
            return new Domain.Entities.SaleType()
            {
                Description = request.Description
            };
        }
    }
}
