using Books.Application.UseCases.Book.Create;
using Books.Domain.Entities;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using Moq;
using Xunit;

namespace Books.Test.Book
{
    public class CreateHandlerTests
    {
        private readonly Mock<ICommandBase<Domain.Entities.Book>> _bookCommandMock;
        private readonly Mock<IQueryBase<Author>> _authorQueryMock;
        private readonly Mock<IQueryBase<Subject>> _subjectQueryMock;
        private readonly CreateHandler _handler;

        public CreateHandlerTests()
        {
            _bookCommandMock = new Mock<ICommandBase<Domain.Entities.Book>>();
            _authorQueryMock = new Mock<IQueryBase<Author>>();
            _subjectQueryMock = new Mock<IQueryBase<Subject>>();

            _handler = new CreateHandler(
                _bookCommandMock.Object,
                _authorQueryMock.Object,
                _subjectQueryMock.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldCreateBookWithCorrectData()
        {
            // Arrange
            var request = new CreateCommand
            (
                "Test Title",
                "Test Publisher",
                1,
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
                new Subject { Id = 1, Description = "Subject 1" },
                new Subject { Id = 2, Description = "Subject 2" }
            };

            _authorQueryMock.Setup(q => q.Query()).Returns(authors.AsQueryable());
            _subjectQueryMock.Setup(q => q.Query()).Returns(subjects.AsQueryable());

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            _bookCommandMock.Verify(cmd => cmd.Insert(It.Is<Domain.Entities.Book>(b =>
                b.Title == request.Title &&
                b.Publisher == request.Publisher &&
                b.Edition == request.Edition &&
                b.PublicationYear == request.PublicationYear &&
                b.Authors.Count == request.AuthorIds.Count &&
                b.Subjects.Count == request.SubjectIds.Count &&
                b.Prices.Count == request.Prices.Count
            )), Times.Once);

            _bookCommandMock.Verify(cmd => cmd.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
