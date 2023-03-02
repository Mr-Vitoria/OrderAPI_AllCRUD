using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.ClientService
{
    public class PlugDaoClient //: IDaoClient
    {
        public static List<ClientModel> clients = new List<ClientModel>();

        public Task<ClientModel> AddClient(ClientModel client)
        {
            client.Id=clients.Count;
            clients.Add(client);
            return Task.Run(()=>client);
        }

        public Task<bool> DeleteClient(ClientModel client)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientModel>> GetAllClients()
        {
            return Task.Run(()=>clients);
        }

        public Task<ClientModel> GetClientById()
        {
            throw new NotImplementedException();
        }

        public Task<ClientModel> UpdateClient(ClientModel client)
        {
            throw new NotImplementedException();
        }
    }
}
