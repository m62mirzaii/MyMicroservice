using Ordering.Domain.Base;

namespace Ordering.Domain.Entities.Orders;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }

    public OrderItem(string name, decimal price, decimal discount)
    {
        Name = name;
        Price = price;
        Discount = discount;
    }
}
