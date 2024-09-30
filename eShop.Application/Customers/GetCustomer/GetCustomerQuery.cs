using eShop.Domain.Customers;
using MediatR;

namespace eShop.Application.Customers.GetCustomer
{
    public record GetCustomerQuery(Guid Id) : IRequest<Customer>;
}
