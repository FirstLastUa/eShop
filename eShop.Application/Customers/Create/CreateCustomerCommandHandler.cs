using eShop.Domain.Core;
using eShop.Domain.Customers;
using MediatR;

namespace eShop.Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        async Task<Customer> IRequestHandler<CreateCustomerCommand, Customer>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var firstName = FirstName.Create(request.FirstName);
            var lastName = LastName.Create(request.LastName);
            var email = EmailAddress.Create(request.Email);

            if (firstName.IsFailure || lastName.IsFailure || email.IsFailure)
            {
                //TODO: handle error
                throw new ArgumentException();
            }

            var customer = Customer.Create(firstName.Value, lastName.Value, email.Value);

            _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
