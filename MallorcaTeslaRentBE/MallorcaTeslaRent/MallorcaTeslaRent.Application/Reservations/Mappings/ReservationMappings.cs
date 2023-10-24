using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MallorcaTeslaRent.Application.Reservations.Mappings;
[Mapper]
public partial class ReservationMappings
{
    public partial ReservationDto ReservationToReservationDto(Reservation reservation);
    public partial Reservation ReservationDtoToReservation(ReservationDto reservationDto);
    public partial IEnumerable<ReservationDto> MapReservationDtosToReservations(IEnumerable<Reservation> reservation);
    
    public Reservation UpdateReservation(ReservationDto reservationDto,Reservation reservation)
    {
        reservation.StartDate = reservationDto.StartDate;
        reservation.EndDate = reservationDto.EndDate;
        reservation.TotalPrice = reservationDto.TotalPrice;
        return reservation;
    }
}