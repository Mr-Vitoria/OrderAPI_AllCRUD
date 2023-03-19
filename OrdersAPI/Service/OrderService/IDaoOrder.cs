using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.OrderService
{
    public interface IDaoOrder :IDaoTemplate<OrderModel>
    {
        Task<List<OrderModel>> GetFullAllOrders();
        Task<OrderModel> GetFullOrderById(int id);
        Task<object> Bill(int id);
        Task<object> FullOrderInfo(int id);
        
    }
}
