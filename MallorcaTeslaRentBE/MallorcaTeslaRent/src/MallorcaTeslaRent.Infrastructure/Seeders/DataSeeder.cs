using System.Text.Json;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace MallorcaTeslaRent.Infrastructure.Seeders
{
    public class DataSeeder
    {
        private readonly MallorcaTeslaRentDbContext _dbContext;


        public DataSeeder(MallorcaTeslaRentDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task SeedAsync()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var usersJsonPath = Path.Combine(baseDirectory, "Seeders", "users.json");
            var rentalLocationsJsonPath = Path.Combine(baseDirectory, "Seeders", "rentalLocations.json");
            var carsJsonPath = Path.Combine(baseDirectory, "Seeders", "cars.json");

            if (!_dbContext.Users.Any())
            {
                var usersData = await File.ReadAllTextAsync(usersJsonPath);
                var users = JsonSerializer.Deserialize<List<User>>(usersData);

                if (users != null)
                {
                    foreach (var user in users)
                    {
                        _dbContext.Users.Add(user);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.RentalLocations.Any())
            {
                var rentalLocationsData = await File.ReadAllTextAsync(rentalLocationsJsonPath);
                var rentalLocations = JsonSerializer.Deserialize<List<RentalLocation>>(rentalLocationsData);

                if (rentalLocations != null)
                {
                    foreach (var rentalLocation in rentalLocations)
                    {
                        _dbContext.RentalLocations.Add(rentalLocation);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.Cars.Any())
            {
                var carsData = await File.ReadAllTextAsync(carsJsonPath);
                var cars = JsonSerializer.Deserialize<List<Car>>(carsData);

                if (cars != null)
                {
                    foreach (var car in cars)
                    {
                        _dbContext.Cars.Add(car);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
