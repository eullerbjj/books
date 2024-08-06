using Books.Application.UseCases.Author;

namespace Books.API.Response
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static explicit operator AuthorResponse(AuthorResult author)
        {
            return new AuthorResponse
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public static explicit operator AuthorResponse(Domain.Entities.Author author)
        {
            return new AuthorResponse
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}
