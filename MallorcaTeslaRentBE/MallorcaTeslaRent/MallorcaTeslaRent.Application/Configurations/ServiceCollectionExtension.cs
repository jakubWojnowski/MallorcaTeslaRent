using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace MallorcaTeslaRent.Application.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}