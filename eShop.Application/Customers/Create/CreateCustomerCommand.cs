using eShop.Domain.Customers;
using MediatR;

namespace eShop.Application.Customers.Create
{
    public record CreateCustomerCommand(string FirstName, string LastName, string Email) : IRequest<Customer>;
}
