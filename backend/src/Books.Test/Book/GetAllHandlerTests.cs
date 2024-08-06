using Books.Application.UseCases.Book.GetAll;
using Books.Domain.Interfaces.Queries;
using Moq;
using Xunit;

namespace Books.Test.Book
{
    public class GetAllHandlerTests
    {
        private readonly Mock<IQueryBase<Domain.Entities.Book>> _queryMock;
        private readonly GetAllHandler _handler;

        public GetAllHandlerTests()
        {
            _queryMock = new Mock<IQueryBase<Domain.Entities.Book>>();
            _handler = new GetAllHandler(_queryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Domain.Entities.Book>
            {
                new Domain.Entities.Book { Id = 1, Title = "Book 1" },
                new Domain.Entities.Book { Id = 2, Title = "Book 2" }
            };
            _queryMock.Setup(q => q.GetAllAsync()).ReturnsAsync(books);

            var request = new GetAllQuery();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(books.Count, result.Books.Count());

            var bookResults = result.Books.ToList();
            for (int i = 0; i < books.Count; i++)
            {
                Assert.Equal(books[i].Id, bookResults[i].Id);
                Assert.Equal(books[i].Title, bookResults[i].Title);
            }
        }
    }
}