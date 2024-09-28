using eShop.Domain.Customers;
using eShop.Domain.Orders;
using eShop.Domain.Products;

namespace eShop.Domain.Core
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        IOrderRepository OrderRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
