using Dapper;
using MetroBasketApi.Dapper.Interfaces;
using MetroBasketApi.Data.Interfaces;
using MetroBasketApi.Models;
using System.Data.SqlClient;

namespace MetroBasketApi.Data
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IConfiguration configuration;

        public ArticleRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Article article)
        {
            var sql = "Insert into Articles (Name, Price, Basket_Id) VALUES (@Name, @Price, @BasketId)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, article);
                return result;
            }
        }

       public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Article>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Article entity)
        {
            throw new NotImplementedException();
        }
    }

}
