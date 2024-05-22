using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Order.Commands.ProcessUnscheduledOrders;
    
public sealed record ProcessUnscheduledOrdersCommand(Dictionary<string, Domain.Entities.Order> ordersinventory) : ICommand;