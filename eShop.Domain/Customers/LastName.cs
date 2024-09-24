using eShop.Domain.Core.Primitives.Result;
using static eShop.Domain.Customers.Errors;

namespace eShop.Domain.Customers
{
    public record LastName
    {
        public const int MaxLength = 50;

        public string Value { get; }

        private LastName(string value)
        {
            Value = value;
        }

        public static Result<LastName> Create(string lastName)
        {
            return Result.Create(lastName, CustomerErrors.LastNameIsNull)
                .Ensure(f => f.Length <= MaxLength, CustomerErrors.LastNameTooLong)
                .Map(f => new LastName(f));
        }
    }
}
