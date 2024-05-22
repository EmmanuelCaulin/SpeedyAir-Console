using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Mediator.Contracts;
using SpeedyAir.Application.Order.Commands.ProcessUnscheduledOrders;
using SpeedyAir.Domain.Contracts.Repository;
using SpeedyAir.Persistence.Repositories;

namespace SpeedyAir.Application.Mediator.Commands.Order.ProcessUnscheduledOrders
{
    public sealed class ProcessUnscheduledOrdersCommandMediator : ICommandMediatorAsync<ProcessUnscheduledOrdersCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ProcessUnscheduledOrdersCommandMediator()
        {
            // This should be provided via constructor injection in real application.
            _orderRepository = new OrderRepository();
        }

        public async Task<IResponse> Send(ICommand command)
        {
            var handler = ProcessUnscheduledOrdersCommandHandler.Create(_orderRepository);
            var response = await handler.Handle((ProcessUnscheduledOrdersCommand)command);

            return response;
        }
    }
}
