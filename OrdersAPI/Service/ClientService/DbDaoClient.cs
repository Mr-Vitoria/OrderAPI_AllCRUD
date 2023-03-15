using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.ClientService
{
    public class DbDaoClient : IDaoTemplate<ClientModel>
    {
        ApplicationDbContext db;
        public DbDaoClient(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ClientModel> Add(ClientModel element)
        {
            element.Id = await db.Clients.CountAsync();
            await db.Clients.AddAsync(element);
            await db.SaveChangesAsync();
            return element;
        }

        public async Task<bool> Delete(int id)
        {
            ClientModel client = await db.Clients.FirstOrDefaultAsync(cl => cl.Id == id);

            if (client != null)
            {
                db.Clients.Remove(client);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ClientModel>> GetAll()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task<ClientModel> GetById(int id)
        {
            return await db.Clients.FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<ClientModel> Update(ClientModel element)
        {
            db.Clients.Update(element);
            await db.SaveChangesAsync();
            return element;
        }
    }
}
