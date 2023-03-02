using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.OrderService
{
    public class DbDaoOrder : IDaoOrder
    {
        ApplicationDbContext db;
        public DbDaoOrder(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<OrderModel> AddOrder(OrderModel order)
        {
            order.Id = await db.Orders.CountAsync();
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;

        }

        public async Task<bool> DeleteOrder(int id)
        {
            OrderModel order = await db.Orders.FirstOrDefaultAsync(or => or.Id == id);

            if (order != null)
            {
                db.Orders.Remove(order);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<OrderModel>> GetAllOrders()
        {
            return await db.Orders.ToListAsync();    
        }

        public async Task<OrderModel> GetOrderById(int id)
        {
            return await db.Orders.FirstOrDefaultAsync(or => or.Id == id);
        }

        public async Task<OrderModel> UpdateOrder(OrderModel order)
        {
            db.Orders.Update(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
