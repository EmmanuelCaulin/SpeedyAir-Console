using SpeedyAir.Domain.Entities;

namespace SpeedyAir.Domain.Contracts.Repository
{
    public interface IOrderRepository
    {
        Task<List<string>> ArrangeOrdersForToday(Dictionary<string, Order> ordersInventory, string destination);
        Task<List<string>> ArrangeUnscheduledOrders(Dictionary<string, Order> ordersInventory, List<string> ordersWith);
    }
}
