namespace Books.Application.UseCases.Book.GetAll
{
    public sealed class GetAllResult
    {
        public GetAllResult(IEnumerable<BookResult> books)
        {
            Books = books;
        }

        public IEnumerable<BookResult> Books { get; set; } = [];
    }
}
