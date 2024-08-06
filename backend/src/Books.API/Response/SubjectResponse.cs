using Books.Application.UseCases.Subject;

namespace Books.API.Response
{
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public static explicit operator SubjectResponse(SubjectResult subject)
        {
            return new SubjectResponse
            {
                Id = subject.Id,
                Description = subject.Description
            };
        }

        public static explicit operator SubjectResponse(Domain.Entities.Subject subject)
        {
            return new SubjectResponse
            {
                Id = subject.Id,
                Description = subject.Description
            };
        }
    }
}
