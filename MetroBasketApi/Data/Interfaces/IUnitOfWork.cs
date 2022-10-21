using MetroBasketApi.Data.Interfaces;

namespace MetroBasketApi.Dapper.Interfaces
{
    public interface IUnitOfWork
    {
        IBasketRepository Baskets { get; }
        IArticleRepository Articles { get; }

    }
}
