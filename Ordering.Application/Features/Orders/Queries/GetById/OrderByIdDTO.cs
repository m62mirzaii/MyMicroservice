namespace Ordering.Application.Features.Orders.Queries.GetById;

public class OrderByIdDto
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public string CustomerName { get; set; }
}
