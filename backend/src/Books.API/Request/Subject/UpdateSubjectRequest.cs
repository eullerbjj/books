using Books.Application.UseCases.Subject.Update;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.Subject
{
    public class UpdateSubjectRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Description { get; set; } = string.Empty;

        public static UpdateCommand ToCommand(int id, UpdateSubjectRequest request)
        {
            return new UpdateCommand(id, request.Description);
        }
    }
}
