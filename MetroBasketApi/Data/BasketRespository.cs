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
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
