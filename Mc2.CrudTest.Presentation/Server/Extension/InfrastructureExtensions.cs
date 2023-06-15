using FluentValidation;
using Mc2.CrudTest.Presentation.Server.Data.Repositories.Base;
using Mc2.CrudTest.Presentation.Server.Data.Repositories.Customers;
using Mc2.CrudTest.Presentation.Server.Data.Seed;
using Mc2.CrudTest.Presentation.Shared.Core.EFCore;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using System.Reflection;
using CustomerDbContext = Mc2.CrudTest.Presentation.Server.Data.CustomerDbContext;


namespace Mc2.CrudTest.Presentation.Server.Extension;

public static class InfrastructureExtensions
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISieveProcessor, SieveProcessor>();
        builder.Services.AddCustomMediatR(typeof(MyRoot).Assembly);
        builder.Services.AddValidatorsFromAssembly(typeof(MyRoot).Assembly);
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<IDataSeeder, DataSeeder>();


        builder.Services.Configure<SqlOptions>(builder.Configuration.GetSection("SqlOptions"));
        var sqlOptions = builder.Configuration.GetSection("SqlOptions").Get<SqlOptions>();
        builder.Services.AddDbContext<CustomerDbContext>(options =>
        {
            options.UseSqlServer(sqlOptions.ConnectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.EnableSensitiveDataLogging();
        });

        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

        return builder;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMigration<CustomerDbContext>();

        return app;
    }
}
