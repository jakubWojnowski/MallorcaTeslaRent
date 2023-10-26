using MallorcaTeslaRent.Application.Reservations.Dto;

namespace MallorcaTeslaRent.Application.Cars.Dto;

public class CarAndReservationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public decimal PricePerDay { get; set; }
    public int NumberOfSeats { get; set; }

    public List<ReservationDto> Reservations { get; set; }
}