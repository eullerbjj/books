using Books.Application.Exceptions;
using Books.Application.UseCases.Book.Delete;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using Moq;
using Xunit;

namespace Books.Test.Book
{
    public class DeleteHandlerTests
    {
        private readonly Mock<ICommandBase<Domain.Entities.Book>> _commandMock;
        private readonly Mock<IQueryBase<Domain.Entities.Book>> _queryMock;
        private readonly DeleteHandler _handler;

        public DeleteHandlerTests()
        {
            _commandMock = new Mock<ICommandBase<Domain.Entities.Book>>();
            _queryMock = new Mock<IQueryBase<Domain.Entities.Book>>();

            _handler = new DeleteHandler(_commandMock.Object, _queryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteBook_WhenBookExists()
        {
            // Arrange
            var existingBook = new Domain.Entities.Book { Id = 1, Title = "Test Book" };
            var request = new DeleteCommand(1);

            _queryMock.Setup(q => q.GetByIdAsync(request.Id)).ReturnsAsync(existingBook);

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            _commandMock.Verify(cmd => cmd.Delete(It.Is<Domain.Entities.Book>(b => b.Id == existingBook.Id)), Times.Once);
            _commandMock.Verify(cmd => cmd.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenBookDoesNotExist()
        {
            // Arrange
            var request = new DeleteCommand(999);

            _queryMock.Setup(q => q.GetByIdAsync(request.Id)).ReturnsAsync((Domain.Entities.Book)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}