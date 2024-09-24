using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Orders
{
    public static partial class Errors
    {
        public static class OrderErrors
        {
            public static readonly Error CustomerIdEmpty = new("Order.CustomerIdIsEmpty", "Customer ID is empty");
        }

        public static class OrderItemErrors
        {
            public static readonly Error IdEmpty = new("OrderItem.IdIsEmpty", "OrderItem ID is empty");
            public static readonly Error NegativeQuantity = new("OrderItem.NegativeQuantity", "OrderItem quantity is less than zero");
            public static readonly Error NotEnoughItemsInTheOrder = new("OrderItem.NotEnoughItemsToDecrease", "Not enough items in the order");
        }
    }
}
