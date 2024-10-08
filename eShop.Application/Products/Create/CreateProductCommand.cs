using eShop.Domain.Products;
using MediatR;

namespace eShop.Application.Products.Create
{
    public record CreateProductCommand(string Name, string Description, Money Money, bool IsAvailable) : IRequest<Product>;
}
