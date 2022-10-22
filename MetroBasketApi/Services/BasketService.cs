using MetroBasketApi.Dapper.Interfaces;
using MetroBasketApi.Models;
using MetroBasketApi.Models.Enums;
using MetroBasketApi.Services.Interfaces;

namespace MetroBasketApi.Services
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork unitOfWork;
        public BasketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateBasket(string customer, bool paysVAT)
        {
            return await unitOfWork.Baskets.AddAsync(new Basket(customer, paysVAT, Models.Enums.BasketStatusEnum.Open));
        }

        public async Task<int> UpdateStatus(int id, BasketStatusEnum status)
        {   
            return await unitOfWork.Baskets.UpdateStatus((int)status, id);
        }

        public async Task<Basket> GetBasket(int id)
        {
            var basket = await unitOfWork.Baskets.GetByIdAsync(id);
            foreach (var item in basket.Articles)
            {
                basket.TotalNet += item.Price;
                basket.TotalGross += basket.CustomerPaysVat ? item.Price + item.Price * 0.3 : item.Price;
            }
            return basket;
        }

        public async Task<int> AddArticle(string name, double price, int basketId)
        {
            return await unitOfWork.Articles.AddAsync(new Article(name, price, basketId));
        }
    }
}
