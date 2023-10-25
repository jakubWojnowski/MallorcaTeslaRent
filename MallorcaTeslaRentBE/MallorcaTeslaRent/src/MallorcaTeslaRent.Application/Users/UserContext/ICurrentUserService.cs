namespace MallorcaTeslaRent.Application.Users.UserContext;

public interface ICurrentUserService
{
    CurrentUser? GetCurrentUser();
}