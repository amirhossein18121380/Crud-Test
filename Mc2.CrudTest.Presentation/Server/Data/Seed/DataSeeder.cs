using Mc2.CrudTest.Presentation.Shared.Core.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Data.Seed;
public class DataSeeder : IDataSeeder
{
    private readonly DbContext _customerDbContext;

    public DataSeeder(DbContext customerDbContext)
    {
        _customerDbContext = customerDbContext;
    }

    public async Task SeedAllAsync()
    {
        await SeedCustomerAsync();
    }

    private async Task SeedCustomerAsync()
    {
        if (!await _customerDbContext.Customers.AnyAsync())
        {
            await _customerDbContext.Customers.AddRangeAsync(InitialData.Customers);
            await _customerDbContext.SaveChangesAsync();
        }
    }
}
