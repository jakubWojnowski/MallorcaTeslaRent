﻿namespace MallorcaTeslaRent.Domain.Exceptions;

public class ReservationException : Exception
{
    public ReservationException(string message) : base(message)
    {
        
    }
}