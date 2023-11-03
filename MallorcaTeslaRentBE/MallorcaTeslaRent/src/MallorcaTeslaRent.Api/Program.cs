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
    builder.Services.AddCors();
    
var app = builder.Build();

app.UseSwagger();
app.UseHttpsRedirection();
app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));
app.UseAuthentication();

app.UseAuthorization();
app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "MallorcaTeslaRent"));
app.MapControllers();
app.Run();

