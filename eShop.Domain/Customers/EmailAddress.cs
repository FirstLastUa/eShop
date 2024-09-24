using System.Text.RegularExpressions;
using eShop.Domain.Core.Primitives.Result;
using static eShop.Domain.Customers.Errors;

namespace eShop.Domain.Customers
{
    public record EmailAddress
    {
        private static readonly string _pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public string Address { get; private set; }

        private EmailAddress(string value)
        {
            Address = value;
        }

        public static Result<EmailAddress> Create(string address)
        {
            return IsValid(address)
                ? Result.Success(new EmailAddress(address))
                : Result.Failure<EmailAddress>(EmailErrors.InvalidEmail);
        }

        private static bool IsValid(string address)
        {
            return Regex.IsMatch(address, _pattern);
        }
    }
}
