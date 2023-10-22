using MallorcaTeslaRent.Application.Cars.Dto;

namespace MallorcaTeslaRent.Application.RentalLocations.Dto;

public class RenatLocationAndCarDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<CarDto> Cars { get; set; }
}