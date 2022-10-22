using Dapper;
using MetroBasketApi.Dapper.Interfaces;
using MetroBasketApi.Models;
using System.Data.SqlClient;

namespace MetroBasketApi.Data
{
    public class BasketRespository : IBasketRepository
    {
        private readonly IConfiguration configuration;

        public BasketRespository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Basket basket)
        {
            var sql = "Insert into Baskets (Customer, Pays_Vat) VALUES (@Customer, @CustomerPaysVat)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, basket);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Basket>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Basket> GetByIdAsync(int id)
        {
            var basket = new Basket();
            var sqlBasket = "SELECT b.Id, b.Pays_Vat, b.Customer FROM Baskets b WHERE Id = @Id";
            var sqlArticles = "SELECT ar.Price, ar.Name, ar.Id, ar.Basket_Id as BasketId from Articles ar Where Basket_Id =@Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var basketData = await connection.QueryAsync<Basket>(sqlBasket, new { Id = id });
                var articlesData = await connection.QueryAsync<Article>(sqlArticles, new { Id = id });
                basket = basketData.First();
                basket.Articles = articlesData.ToList();
                return basket;
            }
        }
        public async Task<int> UpdateStatus(int status, int Id)
        {
            var sql = "Update Baskets SET Status = @status where Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new {status, Id});
                return result;
            }
        }
        public async Task<int> UpdateAsync(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
