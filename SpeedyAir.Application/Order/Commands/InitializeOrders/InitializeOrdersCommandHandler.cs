using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Order.Commands.InitializedOrders;
using SpeedyAir.Domain.Contracts.Repository;
using SpeedyAir.Infrastructure.Datasource;
using System.Text.Json;
using System.Threading.Tasks.Sources;

namespace SpeedyAir.Application.Order.Commands.InitializedOrders
{
    internal sealed class InitializeOrdersCommandHandler : ICommandHandler<InitializeOrdersCommand>
    {
        private readonly IOrderRepository _orderRepository;

        private InitializeOrdersCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public static InitializeOrdersCommandHandler Create(IOrderRepository orderRepository)
        {
            return new InitializeOrdersCommandHandler(orderRepository);
        }

        public IResponse Handle(InitializeOrdersCommand command)
        {
            var ordersJson = LoadDatasource.LoadJsonDatasource();

            var ordersInventory = JsonSerializer.Deserialize<Dictionary<string, Domain.Entities.Order>>(ordersJson);

            return new InitializeOrdersResponse(ordersInventory);
        }
    }
}
