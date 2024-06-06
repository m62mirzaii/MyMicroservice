using MediatR;
using Ordering.Domain.Entities.Orders;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Features.Orders.Commands.AddOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new Order(request.OrderNumber, request.CustomerId, request.Status);

        foreach (var item in request.OrderItems)
        {
            entity.AddOrderItem(item.Name, item.Price, item.Discount);
        }

        return await _orderRepository.AddAsync(entity);
    }
}
