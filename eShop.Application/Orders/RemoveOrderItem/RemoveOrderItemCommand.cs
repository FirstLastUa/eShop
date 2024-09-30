using MediatR;

namespace eShop.Application.Orders.RemoveOrderItem
{
    public record RemoveOrderItemCommand(Guid OrderId, Guid OrderItemId) : IRequest;
}
