using eShop.Domain.Orders;
using MediatR;

namespace eShop.Application.Orders.Create
{
    internal sealed class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        //private readonly IBus _bus;

        //public OrderCreatedEventHandler(IBus bus)
        //{
        //    _bus = bus;
        //}

        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // This is a part where event can leave a boundary
            // So, we can use messaging system to send the event for other boundaries or projects

            // await _bus.Send(new OrderCreatedIntegrationEvent(notification.OrderId));
        }
    }
}
