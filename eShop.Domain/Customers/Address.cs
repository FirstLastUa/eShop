using eShop.Domain.Core.Primitives.Result;

namespace eShop.Domain.Customers
{
    public record Address
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }

        private Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        public static Result<Address> Create(string street, string city, string state, string country, string zipcode)
        {
            //TODO: Add validation

            return Result.Success(new Address(street, city, state, country, zipcode));
        }
    }
}
