namespace Books.Application.UseCases.Subject.GetById
{
    public sealed class GetByIdResult : SubjectResult
    {
        public static explicit operator GetByIdResult(Domain.Entities.Subject subject) 
        {
            return new GetByIdResult
            {
                Description = subject.Description,
                Id = subject.Id
            };
        }
    }
}
