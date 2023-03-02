namespace OrdersAPI.Model.Entity
{
    public class OrderProductModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }

        public OrderProductModel()
        {

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
            return $"{Id} - {ProductId} - {OrderId}";
        }
    }
}
