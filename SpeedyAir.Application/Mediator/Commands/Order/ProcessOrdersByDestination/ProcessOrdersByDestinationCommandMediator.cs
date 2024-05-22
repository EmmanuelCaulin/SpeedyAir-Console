using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Mediator.Contracts;
using SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination;
using SpeedyAir.Domain.Contracts.Repository;
using SpeedyAir.Persistence.Repositories;

namespace SpeedyAir.Application.Mediator.Commands.Order.ProcessOrdersByDestination
{
    public sealed class ProcessOrdersByDestinationCommandMediator : ICommandMediatorAsync<ProcessOrdersByDestinationCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ProcessOrdersByDestinationCommandMediator()
        {
            // This should be provided via constructor injection in real application.
            _orderRepository = new OrderRepository();
        }

        public async Task<IResponse> Send(ICommand command)
        {
            var handler = ProcessOrdersByDestinationCommandHandler.Create(_orderRepository);
            var response = await handler.Handle((ProcessOrdersByDestinationCommand)command);

            return response;
        }
    }
}
