namespace MallorcaTeslaRent.Application.Reservations.Dto;

public class ReservationDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set ; } 
    public Guid CarId { get; set; }
}