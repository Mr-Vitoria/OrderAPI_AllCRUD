﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<OrderModel>> GetFullAllOrders()
        {
            //Lazy load
            db.Clients.Load();
            return await db.Orders.ToListAsync();

            //Eager load
            //return await db.Orders.Include(or => or.Client).ToListAsync();
        }

        public async Task<OrderModel> GetFullOrderById(int id)
        {
            await db.OrderProducts.LoadAsync();
            await db.Products.LoadAsync();
            return await db.Orders.FirstOrDefaultAsync(or => or.Id == id);
        }

        public async Task<List<OrderModel>> GetAll()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<OrderModel> GetById(int id)
        {
            return await db.Orders.FirstOrDefaultAsync(or => or.Id == id);
        }

        public async Task<OrderModel> Add(OrderModel element)
        {
            element.Id = await db.Orders.CountAsync();
            await db.Orders.AddAsync(element);
            await db.SaveChangesAsync();
            return element;
        }

        public async Task<OrderModel> Update(OrderModel element)
        {
            db.Orders.Update(element);
            await db.SaveChangesAsync();
            return element;
        }

        public async Task<bool> Delete(int id)
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
    }
}
