using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Mediator.Contracts;
using SpeedyAir.Application.Order.Commands.InitializedOrders;
using SpeedyAir.Domain.Contracts.Repository;
using SpeedyAir.Persistence.Repositories;

namespace SpeedyAir.Application.Mediator.Commands.Order.InitializeOrders
{
    public sealed class InitializeOrdersCommandMediator : ICommandMediator<InitializeOrdersCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public InitializeOrdersCommandMediator()
        {
            // This should be provided via constructor injection in real application.
            _orderRepository = new OrderRepository();
        }

        public IResponse Send(ICommand command)
        {
            var handler = InitializeOrdersCommandHandler.Create(_orderRepository);
            var response = handler.Handle((InitializeOrdersCommand)command);
            return response;
        }
    }
}
