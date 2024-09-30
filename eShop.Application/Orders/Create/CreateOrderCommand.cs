using MediatR;

namespace eShop.Application.Orders.Create
{
    public record CreateOrderCommand(Guid CustomerId) : IRequest;
}
