using eShop.Domain.Core;
using eShop.Domain.Core.Primitives.Result;
using eShop.Domain.Customers;
using MediatR;

namespace eShop.Application.Customers.AddDeliveryAddress
{
    internal sealed class AddDeliveryAddressCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddDeliveryAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(AddDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer is null)
            {
                //TODO: add logic
                return;
            }

            Result<Address> addressResult = Address.Create(request.Street, request.City, request.State, request.Country, request.Zipcode);

            if (addressResult.IsFailure)
            {
                //TODO: add logic
                return;
            }

            customer.AddDeliveryAddress(addressResult.Value);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
