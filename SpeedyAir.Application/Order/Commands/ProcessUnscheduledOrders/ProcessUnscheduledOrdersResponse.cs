using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Order.Commands.ProcessUnscheduledOrders;
    
public sealed record ProcessUnscheduledOrdersResponse(List<string> UnscheduledOrders) : IResponse;