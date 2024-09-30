using eShop.Domain.Core;
using MediatR;

namespace eShop.Application.Orders.AddOrderItem
{
    internal sealed class AddOrderItemCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddOrderItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId, cancellationToken);

            if (order is null)
            {
                //TODO: Add logic
                return;
            }

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product is null)
            {
                //TODO: Add logic
                return;
            }

            order.AddItem(product.Id, request.Quantity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
