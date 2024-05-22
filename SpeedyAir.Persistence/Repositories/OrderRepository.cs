using SpeedyAir.Domain.Contracts.Repository;
using SpeedyAir.Domain.Entities;

namespace SpeedyAir.Persistence.Repositories
{
    public sealed class OrderRepository : IOrderRepository
    {
        public async Task<List<string>> ArrangeOrdersForToday(Dictionary<string, Order> ordersInventory, string destination)
        {
            var orders = await Task.FromResult(ordersInventory.Where(o => o.Value.destination.Equals(destination)).OrderBy(o => o.Key).Select(o => o.Key).Take(20).ToList());
            return orders;
        }

        public async Task<List<string>> ArrangeUnscheduledOrders(Dictionary<string, Order> ordersInventory, List<string> ordersWith)
        {
            var orders = await Task.FromResult(ordersInventory.Where(o => !ordersWith.Contains(o.Value.destination)).OrderBy(o => o.Key).Select(o => o.Key).ToList());
            return orders;
        }
    }
}
