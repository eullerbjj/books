namespace Books.Application.UseCases.SaleType.GetAll
{
    public sealed class GetAllResult
    {
        public GetAllResult(IEnumerable<SaleTypeResult> saletypes)
        {
            SaleTypes = saletypes;
        }

        public IEnumerable<SaleTypeResult> SaleTypes { get; set; } = [];
    }
}
