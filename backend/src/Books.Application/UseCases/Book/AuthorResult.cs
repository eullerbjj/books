using Books.Domain.Entities;

namespace Books.Application.UseCases.Book
{
    public class BookResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int Edition { get; set; }
        public int PublicationYear { get; set; }

        public IEnumerable<Domain.Entities.Author> Authors { get; set; } = [];
        public IEnumerable<Domain.Entities.Subject> Subjects { get; set; } = [];
        public IEnumerable<Price> Prices { get; set; } = [];

        public static explicit operator BookResult(Domain.Entities.Book book)
        {
            return new BookResult
            {
                Id = book.Id,
                Title = book.Title,
                Publisher = book.Publisher,
                Edition = book.Edition,
                PublicationYear = book.PublicationYear,
                Prices = book.Prices,
                Authors = book.Authors,
                Subjects = book.Subjects
            };
        }
    }
}
