using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Flight.Command;
using SpeedyAir.Application.Mediator.Contracts;
using SpeedyAir.Domain.Contracts.Repositories;
using SpeedyAir.Domain.Contracts.Repository;
using SpeedyAir.Persistence.Repositories;

namespace SpeedyAir.Application.Mediator.Commands.Flight.AddFlight
{
    public sealed class AddFlightCommandMediator : ICommandMediator<AddFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;

        public AddFlightCommandMediator()
        {
            // This should be provided via constructor injection in real application.
            _flightRepository = new FlightRepository();
        }

        public IResponse Send(ICommand command)
        {
            var handler = AddFlightCommandHandler.Create(_flightRepository);
            var response = handler.Handle((AddFlightCommand)command);

            return response;
        }
    }
}
