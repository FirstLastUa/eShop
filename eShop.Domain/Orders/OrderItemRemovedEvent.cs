using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Orders
{
    public record OrderItemRemovedEvent(Guid Id, Guid OrderId, Guid OrderItemId) : DomainEvent(Id);
}
