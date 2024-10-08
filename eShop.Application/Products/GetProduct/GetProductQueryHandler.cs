using eShop.Domain.Core;
using eShop.Domain.Products;
using MediatR;

namespace eShop.Application.Products.GetProduct
{
    internal sealed class GetProductQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);

            return product;
        }
    }
}
