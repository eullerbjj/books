using Books.Application.UseCases.Author.Create;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.Author
{
    public sealed class CreateAuthorRequest
    {
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        public static explicit operator CreateCommand(CreateAuthorRequest request)
        {
            return new CreateCommand(request.Name);
        }
    }
}
