using SpeedyAir.Domain.Contracts.Repositories;
using SpeedyAir.Domain.Entities;

namespace SpeedyAir.Persistence.Repositories
{
    public sealed class FlightRepository : IFlightRepository
    {
        public List<Flight> AddFlight(Flight flight, List<Flight> flights)
        {
            flights.Add(flight);
            return flights;
        }
    }
}
