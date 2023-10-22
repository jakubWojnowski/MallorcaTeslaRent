using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Infrastructure.Persistence;
using MallorcaTeslaRent.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MallorcaTeslaRent.Infrastructure.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MallorcaTeslaRentDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MallorcaTeslaRent"));
        });
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        return services;
    }
}