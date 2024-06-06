using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities.Customers; 

namespace Ordering.Infrastructure.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(20);
        builder.Property(e => e.Family).HasMaxLength(30);  
        builder.OwnsOne(e => e.Address, address =>
        {
            address.Property(a => a.Country).HasMaxLength(30);
            address.Property(a => a.City).HasMaxLength(30);
            address.Property(a => a.Street).HasMaxLength(50);
            address.Property(a => a.ZipCode).HasMaxLength(50);
            address.Property(a => a.PostalCode).HasMaxLength(50);
        }); 
    }
}

