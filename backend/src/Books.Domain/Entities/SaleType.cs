namespace Books.Domain.Entities
{
    public sealed class SaleType
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Price> Prices { get; set; } = [];
    }
}
