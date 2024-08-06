namespace Books.Application.UseCases.Subject.GetAll
{
    public sealed class GetAllResult
    {
        public GetAllResult(IEnumerable<SubjectResult> subjects)
        {
            Subjects = subjects;
        }

        public IEnumerable<SubjectResult> Subjects { get; set; } = [];
    }
}
