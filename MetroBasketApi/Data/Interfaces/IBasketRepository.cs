using MetroBasketApi.Models;

namespace MetroBasketApi.Dapper.Interfaces
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task<int> UpdateStatus(int status, int Id);
    }
}
