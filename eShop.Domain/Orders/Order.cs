using eShop.Domain.Core.Primitives;
using eShop.Domain.Core.Primitives.Result;
using static eShop.Domain.Orders.Errors;

namespace eShop.Domain.Orders
{
    public sealed class Order : AggregateRoot
    {
        private readonly HashSet<OrderItem> _orderItems = [];

        public Guid CustomerId { get; private set; }

        public DateTime CreatedAtUtc { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private Order(
            Guid customerId)
            : base(Guid.NewGuid())
        {
            CreatedAtUtc = DateTime.UtcNow;
            CustomerId = customerId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        private Order() { }

        public static Result<Order> Create(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                return Result.Failure<Order>(OrderErrors.CustomerIdEmpty);
            }

            var order = new Order(customerId);

            order.RaiseDomainEvent(new OrderCreatedDomainEvent(Guid.NewGuid(), order.Id));

            return Result.Success(order);
        }

        public void AddItem(Guid productId, int quantity)
        {
            var item = OrderItem.Create(productId, quantity);
            if (item.IsSuccess)
            {
                _orderItems.Add(item.Value);
            }
        }

        public void RemoveItem(Guid productId)
        {
            var item = OrderItems.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                _orderItems.Remove(item);
                RaiseDomainEvent(new OrderItemRemovedEvent(Guid.NewGuid(), Id, item.Id));
            }
        }
    }
}
