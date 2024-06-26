﻿using MediatR;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        return await _orderRepository.DeleteAsync(request.id);
    }
}
