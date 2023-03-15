using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.ProductService
{
    public class DbDaoProduct : IDaoTemplate<ProductModel>
    {
        ApplicationDbContext db;
        public DbDaoProduct(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ProductModel> Add(ProductModel element)
        {
            element.Id = await db.Products.CountAsync();
            await db.Products.AddAsync(element);
            await db.SaveChangesAsync();
            return element;
        }

        public async Task<bool> Delete(int id)
        {
            ProductModel client = await db.Products.FirstOrDefaultAsync(cl => cl.Id == id);

            if (client != null)
            {
                db.Products.Remove(client);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<ProductModel> GetById(int id)
        {
            return await db.Products.FirstOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<ProductModel> Update(ProductModel element)
        {
            db.Products.Update(element);
            await db.SaveChangesAsync();
            return element;
        }
    }
}
