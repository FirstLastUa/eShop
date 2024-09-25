using eShop.Domain.Core.Primitives;
using eShop.Domain.Core.Primitives.Result;
using eShop.Domain.Orders;

namespace eShop.Domain.Customers
{
    public class Customer : AggregateRoot
    {
        private readonly List<Order> _orders = [];

        private readonly HashSet<Address> _deliveryAddresses = [];

        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public EmailAddress Email { get; private set; }

        public IReadOnlyCollection<Order> Orders => _orders;

        public IReadOnlyCollection<Address> DeliveryAddresses => _deliveryAddresses;

        private Customer(
            FirstName firstName,
            LastName lastName,
            EmailAddress emailAddress)
            : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = emailAddress;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        private Customer() { }

        public static Customer Create(FirstName firstName, LastName lastName, EmailAddress email)
        {
            return new Customer(firstName, lastName, email);
        }

        public Result<Order> CreateOrder()
        {
            var order = Order.Create(Id);
            if (!order.IsSuccess)
            {
                return Result.Failure<Order>(order.Error);
            }

            _orders.Add(order.Value);

            return Result.Success(order.Value);
        }

        public void RemoveOrder(Guid orderId)
        {
            var item = Orders.FirstOrDefault(i => i.Id == orderId);
            if (item != null)
            {
                _orders.Remove(item);
            }
        }

        public void AddDeliveryAddress(Address newAddress)
        {
            _deliveryAddresses.Add(newAddress);
        }

        public void RemoveDeliveryAddress(Address address)
        {
            _deliveryAddresses.Remove(address);
        }
    }
}
