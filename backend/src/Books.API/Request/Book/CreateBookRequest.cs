using Books.Application.UseCases.Book.Create;
using Books.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Request.Book
{
    public sealed class CreateBookRequest
    {
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Publisher { get; set; } = string.Empty;

        [Required]
        public int Edition { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        public IList<int> SubjectIds { get; set; } = [];

        public IList<int> AuthorIds { get; set; } = [];

        public IList<PriceRequest> SaleTypePrices { get; set; } = [];

        public static explicit operator CreateCommand(CreateBookRequest request)
        {
            return new CreateCommand(
                request.Title, 
                request.Publisher, 
                request.Edition, 
                request.PublicationYear,
                request.SubjectIds,
                request.AuthorIds,
                request.SaleTypePrices.Select(x => (Price)x).ToList()
            );
        }
    }
}
