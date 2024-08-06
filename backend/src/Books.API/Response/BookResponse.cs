using Books.Application.UseCases.Book;
using Books.Domain.Entities;

namespace Books.API.Response
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int Edition { get; set; }
        public int PublicationYear { get; set; }

        public IEnumerable<AuthorResponse> Authors { get; set; } = [];
        public IEnumerable<SubjectResponse> Subjects { get; set; } = [];
        public IEnumerable<Price> Prices { get; set; } = [];

        public static explicit operator BookResponse(BookResult book)
        {
            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Publisher = book.Publisher,
                Edition = book.Edition,
                PublicationYear = book.PublicationYear,
                Prices = book.Prices,
                Authors = book.Authors.Select(x => (AuthorResponse)x),
                Subjects = book.Subjects.Select(x => (SubjectResponse)x)
            };
        }
    }
}
