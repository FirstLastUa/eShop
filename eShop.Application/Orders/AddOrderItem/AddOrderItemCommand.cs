using MediatR;

namespace eShop.Application.Orders.AddOrderItem
{
    public record AddOrderItemCommand(Guid OrderId, Guid ProductId, int Quantity) : IRequest;
}
