﻿using eShop.Domain.Core;
using eShop.Domain.Customers;
using eShop.Domain.Orders;
using eShop.Domain.Products;
using eShop.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
        {
            builder.AddNpgsqlDbContext<ApplicationDbContext>("eShopDb");

            builder.Services.AddRepositories();

            return builder;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
