namespace eShop.Api.Contracts.Product
{
    public record CreateProductRequest(string Name, string Description, string Currency, decimal Value, bool IsAvailable);
}
