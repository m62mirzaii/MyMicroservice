using MediatR;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Features.Orders.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, OrderByIdDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderByIdDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetByIdAsync(request.Id);

        if(result == null)
            return null;

        return new OrderByIdDto
        {
            Id = result.Id,
            OrderNumber = result.OrderNumber,
            CustomerName = ""
        };
    }
}
