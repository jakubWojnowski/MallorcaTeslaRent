using MallorcaTeslaRent.Application.Car.Dto;
using Riok.Mapperly.Abstractions;
using MallorcaTeslaRent.Domain.Entities;

namespace MallorcaTeslaRent.Application.Car.Mappings;
[Mapper]
public partial class CarMappings 
{
    public partial Domain.Entities.Car MapCarDtoToCar(CarDto carDto);
    public partial CarDto MapCarToCarDto(Domain.Entities.Car car);
    public partial IEnumerable<CarDto> MapCarDtosToCars(IEnumerable<Domain.Entities.Car> car);

    public Domain.Entities.Car UpdateCar(CarDto carDto,Domain.Entities.Car car)
    {
        car.Name = carDto.Name;
        car.Model = carDto.Model;
        car.Description = carDto.Description;
        car.PricePerDay = carDto.PricePerDay;
        car.NumberOfSeats = carDto.NumberOfSeats;
        return car;
    }

} 