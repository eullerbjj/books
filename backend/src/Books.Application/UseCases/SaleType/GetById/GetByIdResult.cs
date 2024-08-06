namespace Books.Application.UseCases.SaleType.GetById
{
    public sealed class GetByIdResult : SaleTypeResult
    {
        public static explicit operator GetByIdResult(Domain.Entities.SaleType saletype) 
        {
            return new GetByIdResult
            {
                Description = saletype.Description,
                Id = saletype.Id
            };
        }
    }
}
