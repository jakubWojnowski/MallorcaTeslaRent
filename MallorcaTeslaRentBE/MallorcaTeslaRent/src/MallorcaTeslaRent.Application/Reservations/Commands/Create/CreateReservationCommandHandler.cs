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
    private readonly IGenericRepository<Reservation, Guid> _reservationRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IGenericRepository<Car, Guid> _carRepository;
    private static readonly ReservationMappings Mapper = new();

    public CreateReservationCommandHandler(IGenericRepository<Reservation, Guid> reservationRepository,
        ICurrentUserService currentUserService, 
        IGenericRepository<Car, Guid> carRepository)
    {
        _reservationRepository = reservationRepository;
        _currentUserService = currentUserService;
        _carRepository = carRepository;
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
        
        return  await _reservationRepository.AddAsync(reservation, cancellationToken);
    }
}