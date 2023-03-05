using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.OrderService
{
    public interface IDaoOrder
    {
        Task<List<OrderModel>> GetAllOrders();
        Task<List<OrderModel>> GetFullAllOrders();
        Task<OrderModel> GetOrderById(int id);
        Task<OrderModel> GetFullOrderById(int id);
        Task<OrderModel> AddOrder(OrderModel order);
        Task<OrderModel> UpdateOrder(OrderModel order);
        Task<bool> DeleteOrder(int id);
    }
}
