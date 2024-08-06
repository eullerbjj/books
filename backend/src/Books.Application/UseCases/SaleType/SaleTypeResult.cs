namespace Books.Application.UseCases.SaleType
{
    public class SaleTypeResult
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public static explicit operator SaleTypeResult(Domain.Entities.SaleType saleType)
        {
            return new SaleTypeResult
            {
                Id = saleType.Id,
                Description = saleType.Description
            };
        }
    }
}
