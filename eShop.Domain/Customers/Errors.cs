using eShop.Domain.Core.Primitives;

namespace eShop.Domain.Customers
{
    public static partial class Errors
    {
        public static class CustomerErrors
        {
            public static readonly Error FirstNameIsNull = new("Customer.FirstNameIsNull", "Customer firstName is null");
            public static readonly Error FirstNameTooLong = new("Customer.FirstNameTooLong", "Customer firstName is too long");
            public static readonly Error LastNameIsNull = new("Customer.LastNameIsNull", "Customer lastName is null");
            public static readonly Error LastNameTooLong = new("Customer.LastNameTooLong", "Customer lastName is too long");
        }

        public static class EmailErrors
        {
            public static readonly Error InvalidEmail = new("Email.InvalidEmail", "Email is not valid");
        }
    }
}
