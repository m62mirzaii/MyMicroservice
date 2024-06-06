using Ordering.Domain.Base;

namespace Ordering.Domain.Entities.Customers;

public class Address : ValueObject
{
    public string Country { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string Street { get; private set; }
    public string PostalCode { get; private set; }

    public Address(string country, string city, string zipCode, string street, string postalCode)
    {
        Country = country;
        City = city;
        ZipCode = zipCode;
        Street = street;
        PostalCode = postalCode;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Country;
        yield return City;
        yield return ZipCode;
        yield return Street;
        yield return PostalCode; 
    }
}
