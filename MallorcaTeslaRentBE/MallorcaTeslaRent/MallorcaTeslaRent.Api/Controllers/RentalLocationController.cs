using MallorcaTeslaRent.Application.RentalLocations.Commands.Create;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Delete;
using MallorcaTeslaRent.Application.RentalLocations.Commands.Update;
using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Query.Get;
using MallorcaTeslaRent.Application.RentalLocations.Query.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslaRent.Controllers;
[Route("api")]
[ApiController]
public class RentalLocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentalLocationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("rentalLocation")]
    public async Task<ActionResult> Create([FromBody] RentalLocationDto rentalLocationDto)
    {
        var id = await _mediator.Send(new CreateRentalLocationCommand(rentalLocationDto));
        return Created($"api/rentalLocation/{id}", id);
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
    public async Task<ActionResult> GetAllWithCars()
    {
        var rentalLocations = await _mediator.Send(new GetRenatLocationsAndCarsQuery());
        return Ok(rentalLocations);
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
}