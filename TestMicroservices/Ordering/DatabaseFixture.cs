using Ordering.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMicroservices.Ordering
{
    internal class DatabaseFixture
    {
    }
}




//using Microsoft.EntityFrameworkCore;
//using System;

//public class DatabaseFixture : IDisposable
//{
//    public OrderContext Context { get; private set; }

//    public DatabaseFixture()
//    {
//        // Setup the in-memory database
//        var options = new DbContextOptionsBuilder<OrderContext>()
//            .UseInMemoryDatabase(databaseName: "TestDatabase")
//            .Options;

//        Context = new OrderContext(options);
//        Context.Database.EnsureCreated();

//        // Optionally, seed the database with initial data
//        SeedDatabase();
//    }

//    private void SeedDatabase()
//    {
//        // Seed initial data if necessary
//        Context.Orders.Add(new Order
//        {
//            OrderNumber = "12345",
//            CustomerId = 1,
//            Status = "Pending",
//            OrderItems = new List<OrderItem>
//            {
//                new OrderItem { Name = "Item1", Price = 100.0m, Discount = 10.0m },
//                new OrderItem { Name = "Item2", Price = 200.0m, Discount = 20.0m }
//            }
//        });
//        Context.SaveChanges();
//    }

//    public void Dispose()
//    {
//        // Clean up the database
//        Context.Database.EnsureDeleted();
//        Context.Dispose();
//    }
//}