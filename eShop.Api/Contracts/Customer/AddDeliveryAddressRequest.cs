namespace eShop.Api.Contracts.Customer
{
    public record AddDeliveryAddressRequest(Guid CustomerId, string Street, string City, string State, string Country, string Zipcode);
}
