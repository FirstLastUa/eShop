using eShop.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).HasConversion(
                firstName => firstName.Value,
                value => FirstName.Create(value).Value);

            builder.Property(c => c.LastName).HasConversion(
                lastName => lastName.Value,
                value => LastName.Create(value).Value);

            builder.Property(c => c.Email).HasConversion(
                email => email.Address,
                value => EmailAddress.Create(value).Value)
                .HasMaxLength(255);

            builder.HasIndex(c => c.Email).IsUnique();

            builder.OwnsMany(c => c.DeliveryAddresses);

            builder.HasMany(c => c.Orders)
                .WithOne()
                .HasForeignKey(o => o.Id);
        }
    }
}
