using MediatR;

namespace Ordering.Application.Features.Orders.Commands.AddOrder;

public class CreateOrderCommand : IRequest<int>
{
    public CreateOrderCommand()
    {
        OrderItems = new List<OrderItem>();
    }

    public int OrderNumber { get; set; }
    public int CustomerId { get; set; }
    public byte Status { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }

    public class OrderItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
