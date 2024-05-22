// See https://aka.ms/new-console-template for more information
using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Enums;
using SpeedyAir.Application.Mediator.Commands.Order.InitializeOrders;
using SpeedyAir.Application.Mediator.Commands.Order.ProcessOrdersByDestination;
using SpeedyAir.Application.Order.Commands.InitializedOrders;
using SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination;

var initializeOrdersCommandMediator = new InitializeOrdersCommandMediator();
var initializeOrdersCommand = new InitializeOrdersCommand();
var ordersInventory = (InitializeOrdersResponse)initializeOrdersCommandMediator.Send(initializeOrdersCommand);

var processOrdersByDestinationCommandMediator = new ProcessOrdersByDestinationCommandMediator();

ICommand processOrdersByDestinationCommand;
ProcessOrdersByDestinationResponse ordersByDestination;

processOrdersByDestinationCommand = new ProcessOrdersByDestinationCommand(ordersInventory.ordersinventory);
ordersByDestination = (ProcessOrdersByDestinationResponse) await processOrdersByDestinationCommandMediator.Send(processOrdersByDestinationCommand);

DisplayOrdersByDestination(ordersByDestination, nameof(FlightSchedule.Day1));

processOrdersByDestinationCommand = new ProcessOrdersByDestinationCommand(ordersByDestination.ordersInventory);
ordersByDestination = (ProcessOrdersByDestinationResponse) await processOrdersByDestinationCommandMediator.Send(processOrdersByDestinationCommand);

DisplayOrdersByDestination(ordersByDestination, nameof(FlightSchedule.Day2));

void DisplayOrdersByDestination(ProcessOrdersByDestinationResponse ordersByDestination, string schedule)
{
    Console.WriteLine($"Flight Schedule: {schedule}");

    Console.WriteLine($"Destination: {nameof(Destination.YYZ)}");
    foreach (var item in ordersByDestination.yyzOrders)
	{
        Console.WriteLine($"Order Number: {item}");
	}

    Console.WriteLine($"Destination: {nameof(Destination.YYC)}");
    foreach (var item in ordersByDestination.yycOrders)
    {
        Console.WriteLine($"Order Number: {item}");
    }

    Console.WriteLine($"Destination: {nameof(Destination.YVR)}");
    foreach (var item in ordersByDestination.yvrOrders)
    {
        Console.WriteLine($"Order Number: {item}");
    }
}