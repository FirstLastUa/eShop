using eShop.Domain.Core;
using eShop.Domain.Customers;
using MediatR;

namespace eShop.Application.Customers.GetCustomer
{
    internal sealed class GetCustomerQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id, cancellationToken);

            return customer;
        }
    }
}
