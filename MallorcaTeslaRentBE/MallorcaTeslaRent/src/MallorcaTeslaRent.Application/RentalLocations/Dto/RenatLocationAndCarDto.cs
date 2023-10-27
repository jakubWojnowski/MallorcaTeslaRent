using MallorcaTeslaRent.Application.Cars.Dto;

namespace MallorcaTeslaRent.Application.RentalLocations.Dto;

public class RenatLocationAndCarDto
{
    Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<CarDto> Cars { get; set; }
}