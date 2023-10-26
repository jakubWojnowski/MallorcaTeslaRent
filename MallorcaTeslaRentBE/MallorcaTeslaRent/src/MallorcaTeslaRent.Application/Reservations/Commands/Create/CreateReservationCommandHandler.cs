using MallorcaTeslaRent.Application.Reservations.Helper;
using MallorcaTeslaRent.Application.Reservations.Mappings;
using MallorcaTeslaRent.Application.Users.UserContext;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Commands.Create;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICarRepository _carRepository;
    private readonly IRentalLocationRepository _rentalLocationRepository;
    private static readonly ReservationMappings Mapper = new();

    public CreateReservationCommandHandler(IReservationRepository reservationRepository,
        ICurrentUserService currentUserService, 
        ICarRepository carRepository,
        IRentalLocationRepository rentalLocationRepository)
    {
        _reservationRepository = reservationRepository;
        _currentUserService = currentUserService;
        _carRepository = carRepository;
        _rentalLocationRepository = rentalLocationRepository;
    }

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {   
        var reservation = Mapper.ReservationDtoToReservation(request.ReservationDto);
        var car = await _carRepository.GetByIdAsync(reservation.CarId, cancellationToken);
        
        if (car is null)
        {
            throw new NotFoundException("Car not found");
        }

        var totalPrice = ReservationPriceHelper.CalculateTotalPrice
        (
            request.ReservationDto.StartDate, 
            request.ReservationDto.EndDate,
            car.PricePerDay
        );
    
        reservation.TotalPrice = totalPrice;
        reservation.UserId = Guid.Parse
        (
            _currentUserService.GetCurrentUser()?.Id ?? throw new NotFoundException("User not found")
        );
        
        var reservations = car.Reservations.Where(c => c.CarId == car.Id);
        if (reservations.Any(r => r.StartDate <= reservation.EndDate && r.EndDate >= reservation.StartDate))
        {
            throw new ReservationException("Car is already reserved for this period");
        }
        
        return  await _reservationRepository.AddAsync(reservation, cancellationToken);
    }
}