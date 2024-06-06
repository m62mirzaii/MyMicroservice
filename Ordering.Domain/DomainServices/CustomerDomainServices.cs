using Ordering.Domain.Repositories;

namespace Ordering.Domain.DomainServices;

public class CustomerDomainServices
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomainServices(IOrderRepository orderRepository, ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
    } 

    public void GetOrderByCustomer(int customerId)
    {

    }
}
