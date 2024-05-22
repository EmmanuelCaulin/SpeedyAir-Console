using SpeedyAir.Application.Contracts;

namespace SpeedyAir.Application.Mediator.Contracts
{
    public interface ICommandMediator<TCommand> where TCommand : ICommand
    {
        IResponse Send(ICommand command);
    }

    public interface ICommandMediatorAsync<TCommand> where TCommand : ICommand
    {
        Task<IResponse> Send(ICommand command);
    }
}
