using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities.Orders;
using Ordering.Domain.Repositories; 
using Ordering.Infrastructure.Repositories.GenericRepositories;

namespace Ordering.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderRepository(IGenericRepository<Order> orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _orderRepository
            .GetAsQueryable()
            .Include(e => e.OrderItems)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Order> GetByOrderNumberAsync(int orderNumber)
    {
        return await _orderRepository.GetAsQueryable()
            .Where(e => e.OrderNumber == orderNumber)
            .FirstAsync();
    }

    public async Task<int> AddAsync(Order order)
    {
        _orderRepository.Add(order);
        await _unitOfWork.SaveChangesAsync();
        return order.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _orderRepository.Delete(id);
        var response = await _unitOfWork.SaveChangesAsync();

        return response;
    }

    public async Task<bool> DeleteOrderItemAsync(int orderId, int orderItemId)
    {
        var order = await GetByIdAsync(orderId);
        order.RemoveOrderItem(orderItemId);
        var response = await _unitOfWork.SaveChangesAsync(); 

        return response;
    }

    public Task<List<Order>> GetByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}

