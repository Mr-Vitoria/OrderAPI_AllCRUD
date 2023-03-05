using System.Text.Json.Serialization;

namespace OrdersAPI.Model.Entity
{
    public class OrderProductModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public ProductModel Product { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public OrderModel Order { get; set; }
        public int Count { get; set; }

        public OrderProductModel()
        {
            Count = 0;
        }

        public OrderProductModel(int id, int productId, ProductModel product, int orderId, OrderModel order)
        {
            Id = id;
            ProductId = productId;
            Product = product;
            OrderId = orderId;
            Order = order;
        }
        public override string ToString()
        {
            return $"{Id} - {ProductId} - {OrderId} - {Count}";
        }
    }
}
