namespace MetroBasketApi.Models
{
    public class Article
    {
        public Article() { }
        public Article(string name, double price, int basketId)
        {
            Name = name;
            Price = price;
            BasketId = basketId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int BasketId { get; set; }
    }
}
