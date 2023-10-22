namespace MallorcaTeslaRent.Application.Cars.Dto;

public class CarDto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public decimal PricePerDay { get; set; }
    public int NumberOfSeats { get; set; }
    
}