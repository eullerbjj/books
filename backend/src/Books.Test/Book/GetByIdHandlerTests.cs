using Books.Application.Exceptions;
using Books.Application.UseCases.Book.GetAll;
using Books.Application.UseCases.Book.GetById;
using Books.Domain.Interfaces.Queries;
using Moq;
using Xunit;

namespace Books.Test.Book
{
    public class GetByIdHandlerTests
    {
        private readonly Mock<IBookQuery> _bookQueryMock;
        private readonly GetByIdHandler _handler;

        public GetByIdHandlerTests()
        {
            _bookQueryMock = new Mock<IBookQuery>();
            _handler = new GetByIdHandler(_bookQueryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            var existingBook = new Domain.Entities.Book { Id = 1, Title = "Test Book" };
            var request = new GetByIdQuery(1);

            _bookQueryMock.Setup(q => q.GetByIdAsync(request.Id)).ReturnsAsync(existingBook);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingBook.Id, result.Id);
            Assert.Equal(existingBook.Title, result.Title);
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenBookDoesNotExist()
        {
            // Arrange
            var request = new GetByIdQuery(999);

            _bookQueryMock.Setup(q => q.GetByIdAsync(request.Id)).ReturnsAsync((Domain.Entities.Book)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}