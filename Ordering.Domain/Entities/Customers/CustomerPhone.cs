using Ordering.Domain.Base;

namespace Ordering.Domain.Entities.Customers;

public class CustomerPhone : BaseEntity, IEntity
{
    public string PreCode { get; private set; }
    public string PhoneNumber { get; private set; }

    public CustomerPhone(string preCode, string phoneNumber)
    {
        preCode = preCode;
        PhoneNumber = phoneNumber;
    }
}
