using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities.Orders;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.DataBaseContext;
using Ordering.Infrastructure.Repositories.GenericRepositories;

namespace Ordering.Infrastructure.Repositories;

//public class OrderRepository2(OrderContext context) : GenericRepository2<Order>(context), IOrderRepository
//{
//    public async Task<Order> GetByOrderNumberAsync(int orderNumber)
//    {
//        return await context.Set<Order>()
//            .AsQueryable()
//            .Where(e => e.OrderNumber == orderNumber)
//            .FirstAsync();
//    }
//}

