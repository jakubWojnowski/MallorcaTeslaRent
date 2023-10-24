using MallorcaTeslaRent.Application.Cars.Commands.Create;
using MallorcaTeslaRent.Application.Cars.Commands.Delete;
using MallorcaTeslaRent.Application.Cars.Commands.Update;
using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Create;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Delete;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Update;
using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslaRent.Controllers;

[Route("api/[controller]")]
[ApiController]
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
    public async Task<ActionResult> CreateCar([FromBody] CarDto carDto, [FromRoute] Guid id)
    {
        var carId = await _mediator.Send(new CreateCarCommand(carDto, id));
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

}