using Books.Application.UseCases.SaleType;

namespace Books.API.Response
{
    public class SaleTypeResponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public static explicit operator SaleTypeResponse(SaleTypeResult saleType)
        {
            return new SaleTypeResponse
            {
                Id = saleType.Id,
                Description = saleType.Description
            };
        }
    }
}
