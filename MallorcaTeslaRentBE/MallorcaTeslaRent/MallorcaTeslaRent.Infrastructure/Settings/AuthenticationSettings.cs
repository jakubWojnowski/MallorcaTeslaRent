namespace MallorcaTeslaRent.Infrastructure.Settings;

internal class AuthenticationSettings
{
    public string JwtKey { get; set; }
    public string JwtIssuer { get; set; }
    public int JwtExpireDays { get; set; }
}