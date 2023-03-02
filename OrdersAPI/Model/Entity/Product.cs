namespace OrdersAPI.Model.Entity
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Article { get; set; }

        public ProductModel()
        {
            Name = "";
        }
        public ProductModel(int id, string? name,int article)
        {
            Id = id;
            Name = name;
            Article = article;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Article}";
        }
    }
}
