using eShop.Domain.Core.Primitives;
using eShop.Domain.Core.Primitives.Result;
using eShop.Domain.Orders;

namespace eShop.Domain.Customers
{
    public class Customer : AggregateRoot
    {
        private readonly List<Order> _orders = [];

        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public EmailAddress Email { get; private set; }

        public Address HomeAddress { get; private set; }

        public IReadOnlyCollection<Order> Orders => _orders;

        private Customer(
            FirstName firstName,
            LastName lastName,
            EmailAddress emailAddress,
            Address homeAddress)
            : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = emailAddress;
            HomeAddress = homeAddress;
        }

        public static Customer Create(FirstName firstName, LastName lastName, EmailAddress email, Address homeAddress)
        {
            return new Customer(firstName, lastName, email, homeAddress);
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
    }
}
