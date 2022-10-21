using MetroBasketApi.Models.Enums;

namespace MetroBasketApi.Models
{
    public class Basket
    {
        public Basket() { }
        public Basket( string customer, bool customerPaysVat, BasketStatusEnum status)
        {
            Customer = customer;
            CustomerPaysVat = customerPaysVat;
            Status = status;
        }

        public int Id { get; set; }
        public string Customer { get; set; }
        public bool CustomerPaysVat { get; set; }
        public BasketStatusEnum Status { get; set; }
        public List<Article> Articles { get; set; }
        public double TotalGross { get; set; }
        public double TotalNet { get; set; }
    }
}
