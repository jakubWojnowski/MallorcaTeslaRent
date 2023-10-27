using MallorcaTeslaRent.Application.Cars.Commands.Create;
using MallorcaTeslaRent.Application.Cars.Commands.Delete;
using MallorcaTeslaRent.Application.Cars.Commands.Update;
using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.Cars.Query.GetList;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Create;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Delete;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Update;
using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.Reservations.Commands.Delete;
using MallorcaTeslaRent.Application.Reservations.Commands.Update;
using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Reservations.Query.Get;
using MallorcaTeslaRent.Application.Reservations.Query.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslaRent.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("rentalLocation")]
    public async Task<ActionResult> Create([FromBody] RentalLocationDto rentalLocationDto)
    {
        var id = await _mediator.Send(new CreateRentalLocationCommand(rentalLocationDto));
        return Created($"api/rentalLocation/{id}", id);
    }


    [HttpDelete("rentalLocation/{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteRentalLocationCommand(id));
        return NoContent();
    }

    [HttpPut("rentalLocation/{id}")]
    public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] RentalLocationDto rentalLocationDto)
    {
        await _mediator.Send(new UpdateRentalLocationCommand(rentalLocationDto, id));
        return NoContent();
    }
    
    [HttpPost("rentalLocation/{id}/car")]
    public async Task<ActionResult> CreateCar([FromBody] AddCarDto addCarDto, [FromRoute] Guid id)
    {
        var carId = await _mediator.Send(new CreateCarCommand(addCarDto, id));
        return Created($"api/car/{carId}", carId);
    }
    [HttpDelete("car/{id}")]
    public async Task<ActionResult> DeleteCar([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteCarCommand(id));
        return NoContent();
    }

    [HttpPut("car/{id}")]
    public async Task<ActionResult> UpdateCar([FromRoute] Guid id, [FromBody] CarDto carDto)
    {
        await _mediator.Send(new UpdateCarCommand(carDto, id));
        return NoContent();
    }
    [HttpGet("Reservation/{id}")]
    public async Task<ActionResult> GetReservation([FromRoute] Guid id)
    {
        var reservation = await _mediator.Send(new GetReservationByIdQuery(id));
        return Ok(reservation);
    }
    
    [HttpGet("Reservations")]
    public async Task<ActionResult> GetAllReservations()
    {
        var reservations = await _mediator.Send(new GetAllReservationsQuery());
        return Ok(reservations);
    }
    [HttpDelete("Reservation/{id}")]
    public async Task<ActionResult> DeleteReservation([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteReservationCommand(id));
        return NoContent();
    }

    [HttpPut("Reservation/{id}")]
    public async Task<ActionResult> UpdateReservation([FromRoute] Guid id, [FromBody] ReservationDto reservationDto)
    {
        await _mediator.Send(new UpdateReservationCommand(reservationDto, id));
        return NoContent();
    }
    [HttpGet("Car/CarsAndReservation")]
    public async Task<ActionResult> GetCarsAndReservation()
    {
        var carsAndReservation = await _mediator.Send(new GetCarsAndReservationsQuery());
        return Ok(carsAndReservation);
    }
    [HttpPut("RentalLocation/{rentalLocationId}/Car/{carId}")]
    public async Task<ActionResult> DropOffCar([FromRoute] Guid carId, [FromRoute] Guid rentalLocationId)
    {
        await _mediator.Send(new CarDropOffCommand(carId, rentalLocationId));
        return NoContent();
    }
}