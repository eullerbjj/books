using Books.Application.UseCases.SaleType.Create;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.SaleType
{
    public sealed class CreateSaleTypeRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Description { get; set; } = string.Empty;

        public static explicit operator CreateCommand(CreateSaleTypeRequest request)
        {
            return new CreateCommand(request.Description);
        }
    }
}
