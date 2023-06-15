using Mc2.CrudTest.Presentation.Shared.Validation;
using MediatR;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Server.Extension;

public static class MediatRExtensions
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
