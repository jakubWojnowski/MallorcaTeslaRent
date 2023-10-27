namespace MallorcaTeslaRent.Application.Reservations.Dto;

public class AddReservationDto
{
    public DateTime StartDate { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
    public DateTime EndDate { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
    public Guid CarId { get; set; }
}