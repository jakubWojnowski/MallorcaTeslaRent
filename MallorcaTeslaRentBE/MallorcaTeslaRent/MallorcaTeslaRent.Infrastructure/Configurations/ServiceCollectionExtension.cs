using MallorcaTeslaRent.Infrastructure.Persistence;
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
        return services;
    }
}