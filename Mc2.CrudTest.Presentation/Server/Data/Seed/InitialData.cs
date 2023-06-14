using Mc2.CrudTest.Presentation.Server.Extension;

namespace Mc2.CrudTest.Presentation.Server.Data.Seed;
using Customers.Models;

public static class InitialData
{
    public static List<Customer> Customers { get; }
    static InitialData()
    {
        Customers = new List<Customer>
        {
            Customer.Create(HelperExtensions.GenerateRandomULong(), "John", "Doe", HelperExtensions.RandomDay(),"09361111111","JohnDoe@Gmail.com","123456" ),
            Customer.Create(HelperExtensions.GenerateRandomULong(), "Bob", "Ross", HelperExtensions.RandomDay(),"09361111111","BobRoss@Gmail.com","987654321" )
        };
    }
}
