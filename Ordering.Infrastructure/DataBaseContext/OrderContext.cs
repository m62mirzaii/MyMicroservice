using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Entities.Customers;
using Ordering.Domain.Entities.Orders;
using Ordering.Infrastructure.EntityConfigurations;

namespace Ordering.Infrastructure.DataBaseContext;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);

        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Order> Order { get; set; }
    public DbSet<Customer> Customer { get; set; }

    public DbSet<OutboxMessage> OutboxMessage { get; set; }
}
