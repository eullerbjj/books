using Books.Application.UseCases.SaleType.Update;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.SaleType
{
    public class UpdateSaleTypeRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Description { get; set; } = string.Empty;

        public static UpdateCommand ToCommand(int id, UpdateSaleTypeRequest request)
        {
            return new UpdateCommand(id, request.Description);
        }
    }
}
