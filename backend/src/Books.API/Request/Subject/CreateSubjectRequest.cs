using Books.Application.UseCases.Subject.Create;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.Subject
{
    public sealed class CreateSubjectRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Description { get; set; } = string.Empty;

        public static explicit operator CreateCommand(CreateSubjectRequest request)
        {
            return new CreateCommand(request.Description);
        }
    }
}
