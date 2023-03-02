using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.ClientService
{
    public class DbDaoClient : IDaoClient
    {
        ApplicationDbContext db;
        public DbDaoClient(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ClientModel> AddClient(ClientModel client)
        {
            client.Id = await db.Clients.CountAsync();
            await db.Clients.AddAsync(client);
            await db.SaveChangesAsync();
            return client;
        }

        public async Task<bool> DeleteClient(int id)
        {
            ClientModel client = await db.Clients.FirstOrDefaultAsync(cl => cl.Id == id);

            if(client!=null)
            {
                db.Clients.Remove(client);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ClientModel>> GetAllClients()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            return await db.Clients.FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<ClientModel> UpdateClient(ClientModel client)
        {
            db.Clients.Update(client);
            await db.SaveChangesAsync();
            return client;
        }
    }
}
