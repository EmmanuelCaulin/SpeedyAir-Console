using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination;
    
public sealed record ProcessOrdersByDestinationResponse(
    List<string> yyzOrders,
    List<string> yycOrders,
    List<string> yvrOrders,
    Dictionary<string, Domain.Entities.Order> ordersInventory) : IResponse;
