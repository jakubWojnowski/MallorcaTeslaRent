namespace MallorcaTeslaRent.Application.Users.UserContext;

public interface IIdentityService
{
    Task<bool> Logout();
}