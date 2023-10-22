namespace MallorcaTeslaRent.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "MallorcaTeslaRent", Version = "v1" }); });
    
        return services;
    }
}