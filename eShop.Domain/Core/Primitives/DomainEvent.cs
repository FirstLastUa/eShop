using MediatR;

namespace eShop.Domain.Core.Primitives
{
    public record DomainEvent(Guid Id) : INotification;
}
