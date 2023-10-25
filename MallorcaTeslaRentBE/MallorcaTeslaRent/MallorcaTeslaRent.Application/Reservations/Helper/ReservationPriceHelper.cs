namespace MallorcaTeslaRent.Application.Reservations.Helper;

public static class ReservationPriceHelper
{
    public static decimal CalculateTotalPrice(DateTime startDate, DateTime endDate, decimal pricePerDay)
    {
        var totalDays = (endDate - startDate).Days;
        return totalDays * pricePerDay;
    }
}