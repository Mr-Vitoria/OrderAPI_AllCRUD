using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.OrderProductService
{
    public interface IDaoOrderProduct
    {
        Task<List<OrderProductModel>> GetAllOrderProducts();
        Task<OrderProductModel> GetOrderProductById(int id);
        Task<List<OrderProductModel>> GetProductByOrderId(int id);
        Task<OrderProductModel> AddOrderProduct(OrderProductModel orderProduct);
        Task<OrderProductModel> UpdateOrderProduct(OrderProductModel orderProduct);
        Task<bool> DeleteOrderProduct(int id);
    }
}
