using MallorcaTeslaRent.Application.Cars.Query.Get;
using MallorcaTeslaRent.Application.Cars.Query.GetList;
using MallorcaTeslaRent.Application.RentalLocations.Query.Get;
using MallorcaTeslaRent.Application.RentalLocations.Query.GetList;
using MallorcaTeslaRent.Application.Reservations.Commands.Create;
using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Reservations.Query.Get;
using MallorcaTeslaRent.Application.Reservations.Query.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslaRent.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RentCarController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentCarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("RentalLocation/{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var rentalLocation = await _mediator.Send(new GetRentalLocationByIdQuery(id));
        return Ok(rentalLocation);
    }

    [HttpGet("RentalLocations")]
    public async Task<ActionResult> GetAll()
    {
        var rentalLocations = await _mediator.Send(new GetAllRentalLocationsQuery());
        return Ok(rentalLocations);
    }

    [HttpGet("RentalLocationsAndCars")]
    public async Task<ActionResult> GetRentalLocationsWithCars()
    {
        var rentalLocations = await _mediator.Send(new GetRenatLocationsAndCarsQuery());
        return Ok(rentalLocations);
    }

    [HttpGet("car/{id}")]
    public async Task<ActionResult> GetCar([FromRoute] Guid id)
    {
        var car = await _mediator.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }

    [HttpGet("{locationId}/Cars")]
    public async Task<ActionResult> GetAllCars([FromRoute] Guid locationId)
    {
        var cars = await _mediator.Send(new GetAllCarsByLocationIdQuery(locationId));
        return Ok(cars);
    }

    [HttpPost("Reservation")]
    public async Task<ActionResult> CreateReservation([FromBody] AddReservationDto addReservationDto)
    {
        var reservationId = await _mediator.Send(new CreateReservationCommand(addReservationDto));
        return Ok(reservationId);
    }

    [HttpGet("Reservations")]
    public async Task<ActionResult> GetAllReservationsForUser()
    {
        var reservations = await _mediator.Send(new GetAllReservationsForUserQuery());
        return Ok(reservations);
    }

    [HttpGet("Reservations/{carName}")]
    public async Task<ActionResult> GetReservationByCarName([FromRoute] string carName)
    {
        var reservation = await _mediator.Send(new GetReservationByCarNameQuery(carName));
        return Ok(reservation);
    }
}