namespace Books.Application.UseCases.Author
{
    public class AuthorResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static explicit operator AuthorResult(Domain.Entities.Author author)
        {
            return new AuthorResult
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}
