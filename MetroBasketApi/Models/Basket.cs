namespace MetroBasketApi.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public bool CustomerPaysVat { get; set; }
        public string Status { get; set; }
    }
}
