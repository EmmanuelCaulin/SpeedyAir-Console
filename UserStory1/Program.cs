// See https://aka.ms/new-console-template for more information


using SpeedyAir.Application.Enums;
using SpeedyAir.Application.Flight.Command;
using SpeedyAir.Application.Mediator.Commands.Flight.AddFlight;

var flightList = new List<SpeedyAir.Domain.Entities.Flight>();

var addFlightCommand = new AddFlightCommand(
        (int)Flight.Number1,
        nameof(Destination.YUL),
        nameof(Destination.YYZ),
        (int)FlightSchedule.Day1,
        flightList);
LoadFlightSchedule(addFlightCommand);

addFlightCommand = new AddFlightCommand(
    (int)Flight.Number2,
    nameof(Destination.YUL),
    nameof(Destination.YYC),
    (int)FlightSchedule.Day1,
    flightList);
LoadFlightSchedule(addFlightCommand);

addFlightCommand = new AddFlightCommand(
    (int)Flight.Number3,
    nameof(Destination.YUL),
    nameof(Destination.YVR),
    (int)FlightSchedule.Day1,
    flightList);
LoadFlightSchedule(addFlightCommand);

addFlightCommand = new AddFlightCommand(
        (int)Flight.Number4,
        nameof(Destination.YUL),
        nameof(Destination.YYZ),
        (int)FlightSchedule.Day2,
        flightList);
LoadFlightSchedule(addFlightCommand);

addFlightCommand = new AddFlightCommand(
        (int)Flight.Number5,
        nameof(Destination.YUL),
        nameof(Destination.YYC),
        (int)FlightSchedule.Day2,
        flightList);
LoadFlightSchedule(addFlightCommand);

addFlightCommand = new AddFlightCommand(
        (int)Flight.Number6,
        nameof(Destination.YUL),
        nameof(Destination.YVR),
        (int)FlightSchedule.Day2,
        flightList);
LoadFlightSchedule(addFlightCommand);

DisplayFlightList();

void LoadFlightSchedule(AddFlightCommand command)
{
    var addFlightCommandMediator = new AddFlightCommandMediator();
    var response = addFlightCommandMediator.Send(command);
}

void DisplayFlightList()
{
    Console.Clear();
    Console.WriteLine("Displaying loaded flight schedule!");
    foreach (var flight in flightList) { 
        Console.WriteLine($"Flight: {flight.number}, departure: {flight.departure}, arrival: {flight.arrival}, day: {flight.day}");
    }
    Console.ReadLine();
}
