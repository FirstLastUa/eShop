using MediatR;

namespace eShop.Application.Customers.AddDeliveryAddress
{
    public record AddDeliveryAddressCommand(
        Guid CustomerId, string Street, string City, string State, string Country, string Zipcode) : IRequest;
}
