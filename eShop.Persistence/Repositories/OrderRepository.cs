using eShop.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Repositories
{
    internal class OrderRepository(ApplicationDbContext context)
        : GenericRepository<Order>(context), IOrderRepository
    {
        public override Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return DbContext.Orders
                // Filter only needed OrderItem, so we will not fetch ALL OrderItems for the OrderId
                .Include(o => o.OrderItems.Where(oi => oi.Id == id))
                .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
    }
}
