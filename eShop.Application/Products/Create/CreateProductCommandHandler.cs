using eShop.Domain.Core;
using eShop.Domain.Products;
using MediatR;

namespace eShop.Application.Products.Create
{
    internal sealed class CreateProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Name, request.Description, request.Money, request.IsAvailable);

            _unitOfWork.ProductRepository.Add(product.Value);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Value;
        }
    }
}
