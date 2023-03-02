using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.ProductService
{
    public interface IDaoProduct
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> AddProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<bool> DeleteProduct(int id);
    }
}
