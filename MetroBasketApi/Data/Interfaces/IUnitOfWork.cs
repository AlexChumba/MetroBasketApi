namespace MetroBasketApi.Dapper.Interfaces
{
    public interface IUnitOfWork
    {
        IBasketRepository Baskets { get; }
    }
}
