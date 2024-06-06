using Ordering.Domain.Base;
using Ordering.Domain.DomainEvents.Orders;
namespace Ordering.Domain.Entities.Orders;

public class Order : AggregateRoot, IEntity
{
    public int OrderNumber { get; private set; }
    public int CustomerId { get; private set; }
    public byte Status { get; private set; }
    public DateTime CreateDate { get; private set; }

    private readonly List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;


    private Order() { }

    public Order(int orderNumber, int customerId, byte status)
    {
        OrderNumber = orderNumber;
        CustomerId = customerId;
        Status = status;
        _orderItems = new List<OrderItem>();

        RaisDomainEvent(new OrderRegisteredDomainEvent(orderNumber, customerId));
    }

    public void AddOrderItem(string name, decimal price, decimal discount)
    {
        var item = new OrderItem(name, price, discount);
        _orderItems.Add(item);

        
    }

    public void RemoveOrderItem(int id)
    {
        var item = _orderItems.FirstOrDefault(e => e.Id == id);
        _orderItems.Remove(item);

        


        //DomainEvents.Raise(new OrderItemRemoved(orderItemToRemove));

    }
     
}
