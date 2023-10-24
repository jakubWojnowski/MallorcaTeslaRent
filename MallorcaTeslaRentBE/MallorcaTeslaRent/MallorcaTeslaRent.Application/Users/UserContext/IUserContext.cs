namespace MallorcaTeslaRent.Application.Users.UserContext;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}