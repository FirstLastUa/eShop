using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Products
{
    public static partial class Errors
    {
        public static class ProductErrors
        {
            public static readonly Error NameIsNull = new("Product.NameIsNull", "Product name is null");
        }
    }
}
