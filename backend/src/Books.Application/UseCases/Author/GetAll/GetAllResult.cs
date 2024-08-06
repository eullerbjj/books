namespace Books.Application.UseCases.Author.GetAll
{
    public sealed class GetAllResult
    {
        public GetAllResult(IEnumerable<AuthorResult> authors)
        {
            Authors = authors;
        }

        public IEnumerable<AuthorResult> Authors { get; set; } = [];
    }
}
