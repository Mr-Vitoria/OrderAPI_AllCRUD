using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.ProductService
{
    public class DbDaoProduct : IDaoProduct
    {
        ApplicationDbContext db;
        public DbDaoProduct(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            product.Id = await db.Products.CountAsync();
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
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

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await db.Products.FirstOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return product;
        }
    }
}
