using eShop.Domain.Core.Primitives.Result;
using static eShop.Domain.Customers.Errors;

namespace eShop.Domain.Customers
{
    public record FirstName
    {
        public const int MaxLength = 50;

        public string Value { get; }

        private FirstName(string value)
        {
            Value = value;
        }

        public static Result<FirstName> Create(string firstName)
        {
            return Result.Create(firstName, CustomerErrors.FirstNameIsNull)
                .Ensure(f => f.Length <= MaxLength, CustomerErrors.FirstNameTooLong)
                .Map(f => new FirstName(f));
        }
    }
}
