using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Enums;
using SpeedyAir.Domain.Contracts.Repository;
namespace SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination
{
    internal sealed class ProcessOrdersByDestinationCommandHandler : ICommandHandler<ProcessOrdersByDestinationCommand>
    {
        private readonly IOrderRepository _orderRepository;

        private ProcessOrdersByDestinationCommandHandler(IOrderRepository orderRepository) { 
            _orderRepository = orderRepository;
        }

        public static ProcessOrdersByDestinationCommandHandler Create(IOrderRepository orderRepository)
        {
            return new ProcessOrdersByDestinationCommandHandler(orderRepository);
        }

        public async Task<IResponse> Handle(ProcessOrdersByDestinationCommand command)
        {
            Dictionary<string, Domain.Entities.Order> ordersInventory = command.ordersinventory;
            var yyzOrders = await _orderRepository.ArrangeOrdersForToday(ordersInventory, nameof(Destination.YYZ));
            ordersInventory = ordersInventory.Where(o => !yyzOrders.Contains(o.Key)).ToDictionary();

            var yycOrders = await _orderRepository.ArrangeOrdersForToday(ordersInventory, nameof(Destination.YYC));
            ordersInventory = ordersInventory.Where(o => !yycOrders.Contains(o.Key)).ToDictionary();

            var yvrOrders = await _orderRepository.ArrangeOrdersForToday(ordersInventory, nameof(Destination.YVR));
            ordersInventory = ordersInventory.Where(o => !yvrOrders.Contains(o.Key)).ToDictionary();

            var response = new ProcessOrdersByDestinationResponse(yyzOrders, yycOrders, yvrOrders, ordersInventory);
            return response;
        }
    }
}
