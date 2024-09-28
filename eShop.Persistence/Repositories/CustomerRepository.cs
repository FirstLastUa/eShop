using eShop.Domain.Customers;

namespace eShop.Persistence.Repositories
{
    internal class CustomerRepository(ApplicationDbContext context)
        : GenericRepository<Customer>(context), ICustomerRepository
    {
    }
}
