using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Server.Data;

namespace Test.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public static class DbContextFactory
{
    public static List<Customer> Customers { get; private set; }

    public static CustomerDbContext Create()
    {
        var options = new DbContextOptionsBuilder<CustomerDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

        var context = new CustomerDbContext(options);

        // Seed our data
        EcommerceDataSeeder(context);

        return context;
    }

    private static void EcommerceDataSeeder(CustomerDbContext context)
    {
        Customers = new List<Customer>
        {
            Customer.Create(16994298088341620177,"jack", "jackson", System.DateTime.Now, "09386548975", "Jack@gmail.com", "1234567891"),
            Customer.Create(15994298088341620177, "bob", "nick", System.DateTime.Now, "09113204895", "bob@gmail.com", "9876543218")
        };

        context.Customers.AddRange(Customers);

        context.SaveChanges();
    }

    public static void Destroy(CustomerDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
