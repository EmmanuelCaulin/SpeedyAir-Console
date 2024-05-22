using SpeedyAir.Application.Contracts;
using SpeedyAir.Application.Enums;
using SpeedyAir.Application.Order.Commands.ProcessOrdersByDestination;
using SpeedyAir.Domain.Contracts.Repositories;
using SpeedyAir.Domain.Contracts.Repository;
using SpeedyAir.Persistence.Repositories;

namespace SpeedyAir.Application.Flight.Command
{
    internal sealed class AddFlightCommandHandler : ICommandHandler<AddFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;

        private AddFlightCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public static AddFlightCommandHandler Create(IFlightRepository flightRepository)
        {
            return new AddFlightCommandHandler(flightRepository);
        }

        public IResponse Handle(AddFlightCommand command)
        {
            var flight = new Domain.Entities.Flight()
            {
                number = command.number,
                departure = command.departure,
                arrival = command.arrival,
                day = command.day
            };

            var newFlightList = _flightRepository.AddFlight(flight, command.flights);

            var response = new AddFlightResponse(newFlightList);

            return response;
        }
    }
}
