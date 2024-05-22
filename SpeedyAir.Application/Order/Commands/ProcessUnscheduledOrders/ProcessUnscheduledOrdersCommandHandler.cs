using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Enums;
using SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination;
using SpeedyAir.Domain.Contracts.Repository;

namespace SpeedyAir.Application.Order.Commands.ProcessUnscheduledOrders
{
    internal sealed class ProcessUnscheduledOrdersCommandHandler : ICommandHandler<ProcessUnscheduledOrdersCommand>
    {
        private readonly IOrderRepository _orderRepository;

        private ProcessUnscheduledOrdersCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public static ProcessUnscheduledOrdersCommandHandler Create(IOrderRepository orderRepository)
        {
            return new ProcessUnscheduledOrdersCommandHandler(orderRepository);
        }

        public async Task<IResponse> Handle(ProcessUnscheduledOrdersCommand command)
        {
            Dictionary<string, Domain.Entities.Order> ordersInventory = command.ordersinventory;
            var destinations = new List<String>();
            destinations.Add(nameof(Destination.YYZ));
            destinations.Add(nameof(Destination.YYC));
            destinations.Add(nameof(Destination.YVR));
            var unscheduledOrders = await _orderRepository.ArrangeUnscheduledOrders(ordersInventory, destinations);

            var response = new ProcessUnscheduledOrdersResponse(unscheduledOrders);
            return response;
        }
    }
}
