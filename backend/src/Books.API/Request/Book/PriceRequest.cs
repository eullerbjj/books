using Books.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.Book
{
    public sealed class PriceRequest
    {
        [Required]
        public int SaleTypeId { get; set; }

        [Required]
        public decimal Value { get; set; }

        public static explicit operator Price(PriceRequest priceRequest)
        {
            return new Price()
            {
                SaleTypeId = priceRequest.SaleTypeId,
                Value = priceRequest.Value
            };
        }
    }
}
