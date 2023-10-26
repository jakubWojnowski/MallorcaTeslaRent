namespace MallorcaTeslaRent.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid UserId { get; set; }

    public Guid CarId { get; set; }

    public virtual User? User { get; set; }

    public virtual Car? Car { get; set; }
}