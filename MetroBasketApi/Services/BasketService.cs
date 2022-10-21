using MetroBasketApi.Dapper.Interfaces;
using MetroBasketApi.Models;
using MetroBasketApi.Services.Interfaces;

namespace MetroBasketApi.Services
{
    public class BasketService: IBasketService
    {
        private readonly IUnitOfWork unitOfWork;
        public BasketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateBasket(string customer, bool paysVAT)
        {
            return await unitOfWork.Baskets.AddAsync(new Basket
            {
                Customer = customer,
                CustomerPaysVat = paysVAT
            }); ;

        }

        public async Task<Basket> GetBasket(int id)
        {
            return await unitOfWork.Baskets.GetByIdAsync(id);
        }
    }
}
