using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetById;

public class GetByIdQuery : IRequest<OrderByIdDto>
{
    public int Id { get; set; }
}
