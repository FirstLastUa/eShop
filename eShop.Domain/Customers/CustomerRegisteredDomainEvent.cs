using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Customers
{
    public record CustomerRegisteredDomainEvent(Guid Id) : DomainEvent(Id);
}
