
using MetroBasketApi.Dapper.Interfaces;
using MetroBasketApi.Data.Interfaces;

namespace MetroBasketApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBasketRepository basketRepository, IArticleRepository articleRepository)
        {
            Baskets = basketRepository;
            Articles = articleRepository;
        }

        public IBasketRepository Baskets { get; }
        public IArticleRepository Articles { get; }

    }
}
