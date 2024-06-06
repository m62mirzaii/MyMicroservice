using MediatR;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrderItem;

public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderItemCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        return await _orderRepository.DeleteOrderItemAsync(request.OrderId, request.OrderItemId);
    }
}
