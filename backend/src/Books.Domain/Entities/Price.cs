namespace Books.Domain.Entities
{
    public sealed class Price
    {
        public int BookId { get; set; }
        public int SaleTypeId { get; set; }
        public decimal Value { get; set; }
    }
}
