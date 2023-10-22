using MallorcaTeslaRent.Domain.Enums;

namespace MallorcaTeslaRent.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Role Role { get; set; }

    public virtual ICollection<Reservation>? Reservations { get; set; }
}