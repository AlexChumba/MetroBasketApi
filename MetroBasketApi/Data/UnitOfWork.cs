
using MetroBasketApi.Dapper.Interfaces;

namespace MetroBasketApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBasketRepository basketRepository)
        {
            Baskets = basketRepository;
        }
        public IBasketRepository Baskets { get; }
    }
}
