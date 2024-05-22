using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Flight.Command;
    
public sealed record AddFlightCommand(
    int number,
    string departure,
    string arrival,
    int day,
    List<Domain.Entities.Flight> flights) : ICommand;
