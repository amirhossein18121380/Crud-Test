using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Server.Data.Configurations;
using Mc2.CrudTest.Presentation.Shared.Core.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Data;

public sealed class CustomerDbContext : AppDbContextBase
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(MyRoot).Assembly);
        builder.ApplyConfiguration(new CustomerConfiguration());
    }
}