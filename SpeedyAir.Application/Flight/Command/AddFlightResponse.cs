using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Flight.Command;
    
public sealed record AddFlightResponse(List<Domain.Entities.Flight> flights) : IResponse;