using eShop.Domain.Core.Primitives;
using eShop.Domain.Core.Primitives.Result;
using static eShop.Domain.Products.Errors;

namespace eShop.Domain.Products
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public Money Price { get; private set; }

        public bool IsAvailable { get; private set; }

        private Product(string name, string description, Money price, bool isAvailable)
        {
            Name = name;
            Description = description;
            Price = price;
            IsAvailable = isAvailable;
        }

        public static Result<Product> Create(string name, string description, Money price, bool isAvailable)
        {
            return Result.Create(name, ProductErrors.NameIsNull)
                .Map(f => new Product(name, description, price, isAvailable));
        }
    }
}
