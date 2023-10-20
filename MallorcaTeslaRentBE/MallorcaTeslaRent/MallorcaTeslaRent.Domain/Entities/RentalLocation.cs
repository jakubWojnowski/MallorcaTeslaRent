namespace MallorcaTeslaRent.Domain.Entities;

public class RentalLocation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    
    public List<Reservation> Reservations { get; set; }
}