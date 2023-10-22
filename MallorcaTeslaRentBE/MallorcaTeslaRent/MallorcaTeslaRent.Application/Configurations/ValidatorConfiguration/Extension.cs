using FluentValidation;
using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace MallorcaTeslaRent.Application.Configurations.ValidatorConfiguration;

public static class Extension
{
    public static IServiceCollection RegisterValidators(this IServiceCollection services)
        => services.RegisterUserValidators();

    private static IServiceCollection RegisterUserValidators(this IServiceCollection services)
        => services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
    
    // private static IServiceCollection RegisterCarsValidators(this IServiceCollection services)
    //     => services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
}