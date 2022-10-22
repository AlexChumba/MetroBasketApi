using MetroBasketApi.Models;
using MetroBasketApi.Models.Enums;

namespace MetroBasketApi.Services.Interfaces
{
    public interface IBasketService
    {
        Task<int> CreateBasket(string customer, bool paysVAT);
        Task<Basket> GetBasket(int id);
        Task<int> AddArticle(string name, double price, int basketId);
        Task<int> UpdateStatus(int id, BasketStatusEnum status);
    }
}
