using eShop.Domain.Core;
using eShop.Domain.Customers;
using eShop.Domain.Orders;
using eShop.Domain.Products;
using eShop.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Persistence
{
    /// <summary>
    /// Registers the necessary services with the DI framework.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The same service collection.</returns>
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("eShopDatabase")
                ?? throw new ApplicationException("PostgreSQL connection string is not found");
            var assembly = typeof(ApplicationDbContext).Assembly.GetName();
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(connectionString, x => x.MigrationsAssembly(assembly.Name)));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
