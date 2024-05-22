using SpeedyAir.Domain.Entities;

namespace SpeedyAir.Domain.Contracts.Repositories
{
    public interface IFlightRepository
    {
        List<Flight> AddFlight(Flight flight, List<Flight> flights);
    }
}
