using System.Reflection;
using FluentValidation;
using MallorcaTeslaRent.Application.Configurations.ValidatorConfiguration;
using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.UserContext;
using MallorcaTeslaRent.Application.Users.Validators;
using MallorcaTeslaRent.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MallorcaTeslaRent.Application.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IIdentityService, IdentityService>();

        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        services.RegisterValidators();


        return services;
    }
}