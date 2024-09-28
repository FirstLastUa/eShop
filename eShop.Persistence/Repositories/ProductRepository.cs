using eShop.Domain.Products;

namespace eShop.Persistence.Repositories
{
    internal class ProductRepository(ApplicationDbContext context)
        : GenericRepository<Product>(context), IProductRepository
    {

    }
}
