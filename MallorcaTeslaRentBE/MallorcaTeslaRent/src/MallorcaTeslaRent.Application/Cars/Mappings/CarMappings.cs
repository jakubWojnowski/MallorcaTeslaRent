using MallorcaTeslaRent.Application.Cars.Dto;
using Riok.Mapperly.Abstractions;
using MallorcaTeslaRent.Domain.Entities;

namespace MallorcaTeslaRent.Application.Cars.Mappings;
[Mapper]
public partial class CarMappings 
{
    public partial Car MapCarDtoToCar(CarDto carDto);
    public partial CarDto MapCarToCarDto(Car car);
    public partial IEnumerable<CarDto> MapCarDtosToCars(IEnumerable<Car?> car);
    
    public partial AddCarDto MapCarToAddCarDto(Car car);
    public partial Car MapAddCarDtoToCar(AddCarDto car);
    public partial IEnumerable<CarAndReservationDto> MapCarAndReservationDtosToCarAndReservations(IEnumerable<Car> car);

    public Car UpdateCar(CarDto carDto,Car car)
    {
        car.Name = carDto.Name;
        car.Model = carDto.Model;
        car.Description = carDto.Description;
        car.PricePerDay = carDto.PricePerDay;
        car.NumberOfSeats = carDto.NumberOfSeats;
        return car;
    }

} 