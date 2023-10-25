using FluentValidation;
using FluentValidation.AspNetCore;
using MallorcaTeslaRent.Application.Configurations;
using MallorcaTeslaRent.Configurations;
using MallorcaTeslaRent.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation()
    .AddEndpointsApiExplorer()
    .AddControllers()
    .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<IValidator>());

    
var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "MallorcaTeslaRent"));

app.Run();

