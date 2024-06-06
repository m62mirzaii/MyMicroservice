using Ordering.Domain.Base;
using System.Net;

namespace Ordering.Domain.Entities.Customers;

public class Customer : AggregateRoot, IEntity
{
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string Mobile { get; set; }
    public string NationalityCode { get; private set; }
    public string Email { get; private set; }
    public Address Address { get; private set; }


    private readonly List<CustomerPhone> _customerPhones;
    public IReadOnlyCollection<CustomerPhone> CustomerPhones => _customerPhones;

    private Customer() { }

    public Customer(string name, string family, string mobile, string nationalityCode, string email, Address address)
    {
        Name = name;
        Family = family;
        Mobile = mobile;
        NationalityCode = nationalityCode;
        Email = email;
        Address = address;
        _customerPhones = new List<CustomerPhone>();
    }

    public void AddPhone(string preCode, string number)
    {
        var entity = new CustomerPhone(preCode, number);
        _customerPhones.Add(entity);
    }

    public void RemovePhone(int id)
    {
        var item = _customerPhones.FirstOrDefault(e => e.Id == id);
        _customerPhones.Remove(item);
    }
}
