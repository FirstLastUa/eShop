using eShop.Domain.Products;

namespace eShop.Api.Contracts.Product
{
    public class ProductResponse
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public Money Price { get; private set; }

        public bool IsAvailable { get; private set; }
    }
}
