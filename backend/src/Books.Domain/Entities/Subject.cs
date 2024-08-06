namespace Books.Domain.Entities
{
    public sealed class Subject
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = [];
    }
}
