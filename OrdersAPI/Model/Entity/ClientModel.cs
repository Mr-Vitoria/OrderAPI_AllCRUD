using System.Text.Json.Serialization;

namespace OrdersAPI.Model.Entity
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<OrderModel> Orders { get; set; }

        public ClientModel()
        {
            Name = "";
        }

        public ClientModel(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
