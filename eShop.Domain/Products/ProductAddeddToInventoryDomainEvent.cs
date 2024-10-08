using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Products
{
    public record ProductAddeddToInventoryDomainEvent(Guid Id) : DomainEvent(Id);
}
