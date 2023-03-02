namespace OrdersAPI.Model.Entity
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { get; set; }

        public OrderModel()
        {
            Description = "";
        }
        public OrderModel(int id, string? description, int clientId, ClientModel client)
        {
            Id = id;
            Description = description;
            ClientId = clientId;
            Client = client;
        }

        public override string ToString()
        {
            return $"{Id} - {Description} - {ClientId} - {Client}";
        }
    }
}
