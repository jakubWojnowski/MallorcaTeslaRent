namespace MallorcaTeslaRent.Domain.Exceptions;

public sealed class ResourceAlreadyExistException : Exception
{
    public ResourceAlreadyExistException(string message) : base(message)
    {
        
    }
    // public StatusCode
}