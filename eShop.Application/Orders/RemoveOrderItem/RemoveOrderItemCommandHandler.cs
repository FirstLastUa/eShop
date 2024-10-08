using eShop.Domain.Core;
using MediatR;

namespace eShop.Application.Orders.RemoveOrderItem
{
    internal sealed class RemoveOrderItemCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveOrderItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId, cancellationToken);

            if (order is null)
            {
                //TODO: Add logic
                return;
            }

            order.RemoveItem(request.OrderId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
