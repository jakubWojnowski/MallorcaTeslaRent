using System.Runtime.InteropServices.JavaScript;

namespace MallorcaTeslaRent.Application.Reservations.Dto;

public class ReservationDto
{
    public DateTime StartDate { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
    public DateTime EndDate { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
    public decimal TotalPrice { get; set ; } 
    public Guid CarId { get; set; }
}