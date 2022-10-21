using MetroBasketApi.Models;

namespace MetroBasketApi.Services.Interfaces
{
    public interface IBasketService
    {
        Task<int> CreateBasket(string customer, bool paysVAT);
        Task<Basket> GetBasket(int id);
    }
}
