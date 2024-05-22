namespace SpeedyAir.Application.Contracts;

public interface ICommandHandler<TCommand> where TCommand : ICommand;