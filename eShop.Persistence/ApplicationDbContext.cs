using eShop.Domain.Core.Primitives;
using eShop.Domain.Customers;
using eShop.Domain.Orders;
using eShop.Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IPublisher _publisher;

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
            : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<DomainEvent> domainEvents = ChangeTracker.Entries<AggregateRoot>() // Entity?
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .SelectMany(e => e.Events);

            int result = await base.SaveChangesAsync(cancellationToken);

            foreach (DomainEvent? domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
