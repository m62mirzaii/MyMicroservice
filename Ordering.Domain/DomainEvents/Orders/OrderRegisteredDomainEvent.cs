using Ordering.Domain.Base;

namespace Ordering.Domain.DomainEvents.Orders;

public class OrderRegisteredDomainEvent : IDomainEvent
{
    public int OrderNumber { get; }
    public int CustomerId { get; }

    public OrderRegisteredDomainEvent(int orderNumber, int customerId)
    {
        OrderNumber = orderNumber;
        CustomerId = customerId;
    }
}
