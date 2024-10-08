using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Orders
{
    public record OrderCreatedDomainEvent(Guid Id, Guid OrderId) : DomainEvent(Id);
}
