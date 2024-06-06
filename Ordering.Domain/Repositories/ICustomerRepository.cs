using Ordering.Domain.Entities.Customers;
using Ordering.Domain.Entities.Orders;

namespace Ordering.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Order> GetByIdAsync(int id); 
    
    Task<int> AddAsync(Customer customer);

    Task<bool> DeleteAsync(int id); 

}
