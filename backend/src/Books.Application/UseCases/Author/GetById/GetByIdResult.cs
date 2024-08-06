namespace Books.Application.UseCases.Author.GetById
{
    public sealed class GetByIdResult : AuthorResult
    {
        public static explicit operator GetByIdResult(Domain.Entities.Author author) 
        {
            return new GetByIdResult
            {
                Name = author.Name,
                Id = author.Id
            };
        }
    }
}
