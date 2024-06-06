using Ordering.Domain.Entities.Orders;

namespace Ordering.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);

    Task<Order> GetByOrderNumberAsync(int orderNumber);

    Task<List<Order>> GetByCustomerIdAsync(int customerId);

    Task<int> AddAsync(Order order);

    Task<bool> DeleteAsync(int id);

    Task<bool> DeleteOrderItemAsync(int orderId, int orderItemId); 

}
