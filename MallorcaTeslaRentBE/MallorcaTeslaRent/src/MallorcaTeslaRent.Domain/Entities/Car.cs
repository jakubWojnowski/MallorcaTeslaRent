namespace MallorcaTeslaRent.Domain.Entities;

public class Car
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public  decimal PricePerDay { get; set; }
    public int NumberOfSeats { get; set; }
    
    public Guid RentalLocationId { get; set; }
   
    public virtual RentalLocation RentalLocation { get; set; }
    public virtual ICollection<Reservation>? Reservations { get; set; }
}