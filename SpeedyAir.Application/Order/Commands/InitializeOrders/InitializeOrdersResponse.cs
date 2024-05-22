using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Order.Commands.InitializedOrders;

public sealed record InitializeOrdersResponse(Dictionary<string, Domain.Entities.Order> ordersinventory) : IResponse;
