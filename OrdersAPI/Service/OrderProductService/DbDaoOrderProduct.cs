using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.OrderProductService
{
    public class DbDaoOrderProduct : IDaoTemplate<OrderProductModel>
    {
        ApplicationDbContext db;
        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<OrderProductModel> Add(OrderProductModel element)
        {
            element.Id = await db.OrderProducts.CountAsync();
            await db.OrderProducts.AddAsync(element);
            await db.SaveChangesAsync();
            return element;
        }
        public async Task<bool> Delete(int id)
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

        public async Task<List<OrderProductModel>> GetAll()
        {
            return await db.OrderProducts.ToListAsync();
        }

        public async Task<OrderProductModel> GetById(int id)
        {
            return await db.OrderProducts.FirstOrDefaultAsync(or => or.Id == id);
        }

        public async Task<OrderProductModel> Update(OrderProductModel element)
        {
            db.OrderProducts.Update(element);
            await db.SaveChangesAsync();
            return element;
        }
    }
}
