using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.OrderProductService
{
    public class DbDaoOrderProduct : IDaoOrderProduct
    {
        ApplicationDbContext db;
        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<OrderProductModel> AddOrderProduct(OrderProductModel orderProduct)
        {
            orderProduct.Id = await db.OrderProducts.CountAsync();
            await db.OrderProducts.AddAsync(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }

        public async Task<bool> DeleteOrderProduct(int id)
        {
            OrderProductModel orderProduct = await db.OrderProducts.FirstOrDefaultAsync(or => or.Id == id);

            if (orderProduct != null)
            {
                db.OrderProducts.Remove(orderProduct);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<OrderProductModel>> GetAllOrderProducts()
        {
            return await db.OrderProducts.ToListAsync();
        }

        public async Task<OrderProductModel> GetOrderProductById(int id)
        {
            return await db.OrderProducts.FirstOrDefaultAsync(or => or.Id == id);
        }

        public async Task<OrderProductModel> UpdateOrderProduct(OrderProductModel orderProduct)
        {
            db.OrderProducts.Update(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }
    }
}
