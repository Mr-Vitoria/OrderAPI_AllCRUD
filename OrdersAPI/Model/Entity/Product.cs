using System.Text.Json.Serialization;

namespace OrdersAPI.Model.Entity
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Article { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public ICollection<OrderProductModel> OrderProducts { get; set; }

        public ProductModel()
        {
            Name = "";
        }
        public ProductModel(int id, string? name,int article, int price)
        {
            Id = id;
            Name = name;
            Article = article;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Article} - {Price}";
        }
    }
}
