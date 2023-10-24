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
public class RentalCarController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentalCarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("rentalLocation/{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var rentalLocation = await _mediator.Send(new GetRentalLocationByIdQuery(id));
        return Ok(rentalLocation);
    }

    [HttpGet("rentalLocations")]
    public async Task<ActionResult> GetAll()
    {
        var rentalLocations = await _mediator.Send(new GetAllRentalLocationsQuery());
        return Ok(rentalLocations);
    }

    [HttpGet("rentalLocationsAndCars")]
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

    [HttpGet("cars")]
    public async Task<ActionResult> GetAllCars()
    {
        var cars = await _mediator.Send(new GetAllCarsQuery());
        return Ok(cars);
    }
    
    [HttpPost("Reservation")]
    public async Task<ActionResult> CreateReservation([FromBody] ReservationDto reservationDto)
    {
        var reservationId = await _mediator.Send(new CreateReservationCommand(reservationDto));
        return Ok(reservationId);
    }
    
    
  
    
    // [HttpGet("Reservations/{userId}")]
    // public async Task<ActionResult> GetAllReservationsForUser([FromRoute] Guid userId)
    // {
    //     var reservations = await _mediator.Send(new GetAllReservationsForUserQuery(userId));
    //     return Ok(reservations);
    // }


}