using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination;

public sealed record ProcessOrdersByDestinationCommand(Dictionary<string, Domain.Entities.Order> ordersinventory) : ICommand;
