using Ordering.Domain.Base;

namespace Ordering.Domain.Entities;

public class OutboxMessage : BaseEntity, IEntity
{
    public string Content { get; set; }
    public byte Status { get; set; }
    public DateTime CreateDate { get; set; }    
}
