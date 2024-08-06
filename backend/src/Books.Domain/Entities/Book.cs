namespace Books.Domain.Entities
{
    public sealed class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int Edition { get; set; }
        public int PublicationYear { get; set; }

        public ICollection<Author> Authors { get; set; } = [];
        public ICollection<Subject> Subjects { get; set; } = [];
        public ICollection<Price> Prices { get; set; } = [];
    }
}
