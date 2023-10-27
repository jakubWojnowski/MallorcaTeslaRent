using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Update;

public record CarDropOffCommand(Guid CarId, Guid RentalLocationId) : IRequest;