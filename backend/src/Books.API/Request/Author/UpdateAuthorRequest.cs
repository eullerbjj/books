using Books.Application.UseCases.Author.Update;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.Author
{
    public class UpdateAuthorRequest
    {
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        public static UpdateCommand ToCommand(int id, UpdateAuthorRequest request)
        {
            return new UpdateCommand(id, request.Name);
        }
    }
}
