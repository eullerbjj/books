namespace Books.Application.UseCases.Book.GetById
{
    public sealed class GetByIdResult : BookResult
    {
        public static explicit operator GetByIdResult(Domain.Entities.Book book) 
        {
            return new GetByIdResult
            {
                Title = book.Title,
                Id = book.Id,
                Edition = book.Edition,
                PublicationYear = book.PublicationYear,
                Publisher = book.Publisher,
                Authors = book.Authors,
                Prices = book.Prices,
                Subjects = book.Subjects
            };
        }
    }
}
