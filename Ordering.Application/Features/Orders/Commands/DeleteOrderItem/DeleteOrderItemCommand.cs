using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrderItem;

public  class DeleteOrderItemCommand : IRequest<bool>
{
    public int OrderId { get; set; }
    public int OrderItemId { get; set; }
}
