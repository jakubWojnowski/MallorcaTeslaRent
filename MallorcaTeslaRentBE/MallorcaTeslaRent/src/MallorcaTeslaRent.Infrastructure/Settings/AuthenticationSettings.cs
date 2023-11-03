﻿namespace MallorcaTeslaRent.Infrastructure.Settings;

internal class AuthenticationSettings
{
    public const string SectionName = "Authentication";
    public string JwtKey { get; init; }
    public string JwtIssuer { get; init; }
    public int JwtExpireDays { get; init; }
}