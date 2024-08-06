namespace Books.Application.UseCases.Subject
{
    public class SubjectResult
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public static explicit operator SubjectResult(Domain.Entities.Subject subject)
        {
            return new SubjectResult
            {
                Id = subject.Id,
                Description = subject.Description
            };
        }
    }
}
