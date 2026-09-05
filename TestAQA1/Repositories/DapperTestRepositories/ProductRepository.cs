using AutomationTests.DTO.DapperTestsDTO;
using AutomationTests.Interfaces.DapperTestsInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace AutomationTests.Repositories.DapperTestRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connection;

        public ProductRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            using var db = new SqliteConnection(connection);
            var product = await db.QueryFirstOrDefaultAsync<ProductDTO>(
                "SELECT * FROM Products WHERE Id = @id", new { id = id });
            return product;
        }
    }
}