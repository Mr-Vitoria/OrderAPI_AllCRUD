using OrdersAPI.Model.Entity;

namespace OrdersAPI.Service.ClientService
{
    public interface IDaoClient
    {
        Task<List<ClientModel>> GetAllClients();
        Task<ClientModel> GetClientById(int id);
        Task<ClientModel> AddClient(ClientModel client);
        Task<ClientModel> UpdateClient(ClientModel client);
        Task<bool> DeleteClient(int id);
    }
}
