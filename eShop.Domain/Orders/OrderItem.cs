using eShop.Domain.Core.Primitives;
using eShop.Domain.Core.Primitives.Result;
using static eShop.Domain.Orders.Errors;

namespace eShop.Domain.Orders
{
    public class OrderItem : Entity
    {
        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        private OrderItem(
            Guid productId,
            int quantity) : base(Guid.NewGuid())
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public static Result<OrderItem> Create(Guid productId, int quantity)
        {
            if (productId == Guid.Empty)
            {
                return Result.Failure<OrderItem>(OrderItemErrors.IdEmpty);
            }

            if (quantity <= 0)
            {
                return Result.Failure<OrderItem>(OrderItemErrors.NegativeQuantity);
            }

            return new OrderItem(productId, quantity);
        }

        public Result IncreaseQuantity(int amount)
        {
            if (amount <= 0)
            {
                return Result.Failure(OrderItemErrors.NegativeQuantity);
            }

            Quantity += amount;

            return Result.Success();
        }

        public Result DecreaseQuantity(int amount)
        {
            if (amount > Quantity)
            {
                return Result.Failure(OrderItemErrors.NotEnoughItemsInTheOrder);
            }

            Quantity -= amount;
            return Result.Success();
        }
    }
}
