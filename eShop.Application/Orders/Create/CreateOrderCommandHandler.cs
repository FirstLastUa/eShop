using eShop.Domain.Core;
using eShop.Domain.Core.Primitives.Result;
using eShop.Domain.Customers;
using eShop.Domain.Orders;
using MediatR;

namespace eShop.Application.Orders.Create
{
    internal sealed class CreateOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Customer? customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer is null)
            {
                //TODO: Add logic
                return;
            }

            Result<Order> order = Order.Create(customer.Id);

            if (order.IsFailure)
            {
                //TODO: Add logic
                return;
            }

            _unitOfWork.OrderRepository.Add(order.Value);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
