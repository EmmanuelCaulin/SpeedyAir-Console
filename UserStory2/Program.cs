// See https://aka.ms/new-console-template for more information
using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Enums;
using SpeedyAir.Application.Flight.Command;
using SpeedyAir.Application.Mediator.Commands.Flight.AddFlight;
using SpeedyAir.Application.Mediator.Commands.Order.InitializeOrders;
using SpeedyAir.Application.Mediator.Commands.Order.ProcessOrdersByDestination;
using SpeedyAir.Application.Mediator.Commands.Order.ProcessUnscheduledOrders;
using SpeedyAir.Application.Order.Commands.InitializedOrders;
using SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination;
using SpeedyAir.Application.Order.Commands.ProcessUnscheduledOrders;

var flightList = new List<SpeedyAir.Domain.Entities.Flight>();
AddFlightSchedules();

var initializeOrdersCommandMediator = new InitializeOrdersCommandMediator();
var initializeOrdersCommand = new InitializeOrdersCommand();
var ordersInventory = (InitializeOrdersResponse)initializeOrdersCommandMediator.Send(initializeOrdersCommand);

var processOrdersByDestinationCommandMediator = new ProcessOrdersByDestinationCommandMediator();

ICommand processOrdersByDestinationCommand;
ProcessOrdersByDestinationResponse ordersByDestination;

processOrdersByDestinationCommand = new ProcessOrdersByDestinationCommand(ordersInventory.ordersinventory);
ordersByDestination = (ProcessOrdersByDestinationResponse)await processOrdersByDestinationCommandMediator.Send(processOrdersByDestinationCommand);

DisplayOrders(ordersByDestination, (int)FlightSchedule.Day1);

processOrdersByDestinationCommand = new ProcessOrdersByDestinationCommand(ordersByDestination.ordersInventory);
ordersByDestination = (ProcessOrdersByDestinationResponse)await processOrdersByDestinationCommandMediator.Send(processOrdersByDestinationCommand);

DisplayOrders(ordersByDestination, (int)FlightSchedule.Day2);

var processUnscheduledOrdersCommandMediator = new ProcessUnscheduledOrdersCommandMediator();
var processUnscheduledOrdersCommand = new ProcessUnscheduledOrdersCommand(ordersByDestination.ordersInventory);
var processUnscheduledOrders = (ProcessUnscheduledOrdersResponse)await processUnscheduledOrdersCommandMediator.Send(processUnscheduledOrdersCommand);


DisplayUnscheduledOrders(processUnscheduledOrders.UnscheduledOrders);

void AddFlightSchedules()
{
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
}

void LoadFlightSchedule(AddFlightCommand command)
{
    var addFlightCommandMediator = new AddFlightCommandMediator();
    var response = addFlightCommandMediator.Send(command);
}

void DisplayOrders(ProcessOrdersByDestinationResponse ordersByDestination, int schedule)
{
    Console.WriteLine($"Day: {schedule}");

    DisplayOrdersByDestination(ordersByDestination.yyzOrders, nameof(Destination.YYZ), schedule);
    DisplayOrdersByDestination(ordersByDestination.yycOrders, nameof(Destination.YYC), schedule);
    DisplayOrdersByDestination(ordersByDestination.yvrOrders, nameof(Destination.YVR), schedule);
}

void DisplayUnscheduledOrders(List<string> unsercheduledOrders)
{
    Console.WriteLine("Unscheduled Orders");
    foreach (var item in unsercheduledOrders)
    {
        Console.WriteLine($"Order: {item}, FlightNumber: not scheduled");
    }
}

void DisplayOrdersByDestination(List<string> ordersByDestination, string destination, int schedule)
{
    Console.WriteLine($"Destination: {destination}");
    foreach (var item in ordersByDestination)
    {
        var flightDetails = flightList.Where(f => f.arrival == destination && f.day == schedule).SingleOrDefault();
        Console.WriteLine($"Order: {item}, FlightNumber: {flightDetails.number}, Departure: {flightDetails.departure}, Arrival: {flightDetails.arrival}, Day: {flightDetails.day}");
    }
}