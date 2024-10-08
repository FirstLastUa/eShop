using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Orders
{
    public record OrderCancelledDomainEvent(Guid Id) : DomainEvent(Id);
}
