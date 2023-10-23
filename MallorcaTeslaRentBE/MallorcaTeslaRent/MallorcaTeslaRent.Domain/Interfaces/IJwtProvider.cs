using MallorcaTeslaRent.Domain.Entities;

namespace MallorcaTeslaRent.Domain.Interfaces;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}