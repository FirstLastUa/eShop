using eShop.Domain.Products;
using MediatR;

namespace eShop.Application.Products.GetProduct
{
    public record GetProductQuery(Guid Id) : IRequest<Product>;
}
