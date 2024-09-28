using eShop.Domain.Core;
using eShop.Domain.Customers;
using eShop.Domain.Orders;
using eShop.Domain.Products;

namespace eShop.Persistence.Repositories
{
    internal sealed class UnitOfWork(
        ApplicationDbContext context,
        IProductRepository productRepository,
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository) : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; } = productRepository;

        public IOrderRepository OrderRepository { get; } = orderRepository;

        public ICustomerRepository CustomerRepository { get; } = customerRepository;

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
