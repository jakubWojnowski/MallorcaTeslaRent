namespace MallorcaTeslaRent.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid UserId { get; set; }
    public Guid RentalLocationId { get; set; }
    public Guid CarId { get; set; }
    
    public User User { get; set; }
    public RentalLocation RentalLocation { get; set; }
    public Car Car { get; set; }
}