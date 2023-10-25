namespace MallorcaTeslaRent.Domain.Entities;

public class RentalLocation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
}