using Books.Application.Exceptions;
using Books.Application.UseCases.Book.Update;
using Books.Domain.Entities;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using Moq;
using Xunit;

namespace Books.Test.Book
{
    public class UpdateHandlerTests
    {
        private readonly Mock<ICommandBase<Domain.Entities.Book>> _commandMock;
        private readonly Mock<IQueryBase<Domain.Entities.Book>> _queryMock;
        private readonly Mock<IQueryBase<Author>> _authorQueryMock;
        private readonly Mock<IQueryBase<Subject>> _subjectQueryMock;
        private readonly Mock<IBookQuery> _bookQueryMock;
        private readonly UpdateHandler _handler;

        public UpdateHandlerTests()
        {
            _commandMock = new Mock<ICommandBase<Domain.Entities.Book>>();
            _queryMock = new Mock<IQueryBase<Domain.Entities.Book>>();
            _authorQueryMock = new Mock<IQueryBase<Author>>();
            _subjectQueryMock = new Mock<IQueryBase<Subject>>();
            _bookQueryMock = new Mock<IBookQuery>();

            _handler = new UpdateHandler(
                _commandMock.Object,
                _queryMock.Object,
                _authorQueryMock.Object,
                _subjectQueryMock.Object,
                _bookQueryMock.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldUpdateBookWithCorrectData()
        {
            // Arrange
            var existingBook = new Domain.Entities.Book
            {
                Id = 1,
                Title = "Old Title",
                Publisher = "Old Publisher",
                Edition = 1,
                PublicationYear = 2000,
                Authors = new List<Author>(),
                Subjects = new List<Subject>(),
                Prices = new List<Price>()
            };

            var request = new UpdateCommand(
                1,
                "New Title",
                "New Publisher",
                2,
                2024,
                new List<int> { 1, 2 },
                new List<int> { 3, 4 },
                new List<Price>
                {
                    new Price { SaleTypeId = 1, Value = 100.0m },
                    new Price { SaleTypeId = 2, Value = 150.0m }
                }
            );

            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "Author 1" },
                new Author { Id = 2, Name = "Author 2" }
            };
            var subjects = new List<Subject>
            {
                new Subject { Id = 3, Description = "Subject 1" },
                new Subject { Id = 4, Description = "Subject 2" }
            };

            _bookQueryMock.Setup(bq => bq.GetByIdAsync(request.Id)).ReturnsAsync(existingBook);
            _authorQueryMock.Setup(q => q.Query()).Returns(authors.AsQueryable());
            _subjectQueryMock.Setup(q => q.Query()).Returns(subjects.AsQueryable());

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            _commandMock.Verify(cmd => cmd.Update(It.Is<Domain.Entities.Book>(b =>
                b.Id == existingBook.Id &&
                b.Title == request.Title &&
                b.Publisher == request.Publisher &&
                b.Edition == request.Edition &&
                b.PublicationYear == request.PublicationYear &&
                b.Authors.Count == request.AuthorIds.Count &&
                b.Subjects.Count == request.SubjectIds.Count &&
                b.Prices.Count == request.Prices.Count
            )), Times.Once);

            _commandMock.Verify(cmd => cmd.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenBookDoesNotExist()
        {
            // Arrange
            var request = new UpdateCommand
            (
                999,
                string.Empty,
                string.Empty,
                0,
                0,
                [],
                [],
                []
            );

            _bookQueryMock.Setup(bq => bq.GetByIdAsync(request.Id)).ReturnsAsync((Domain.Entities.Book)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}