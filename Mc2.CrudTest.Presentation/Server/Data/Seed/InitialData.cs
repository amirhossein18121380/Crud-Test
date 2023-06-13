namespace Mc2.CrudTest.Presentation.Server.Data.Seed;
using Customers.Models;

public static class InitialData
{
    public static List<Customer> Customers { get; }
    static InitialData()
    {
        Customers = new List<Customer>
        {
            Customer.Create(Guid.NewGuid(), "John", "Doe", RandomDay(),"09361111111","JohnDoe@Gmail.com","123456" ),
            Customer.Create(Guid.NewGuid(), "Bob", "Ross", RandomDay(),"09361111111","BobRoss@Gmail.com","987654321" )
        };
    }


    private static Random gen = new Random();
    static DateTime RandomDay()
    {
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(gen.Next(range));
    }
}
