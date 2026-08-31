using AutomationTests.DTO.DapperTestsDTO;
using AutomationTests.Interfaces.DapperTestsInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomationTests.Repositories.DapperTestRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connection;

        public CategoryRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            using var db = new SqliteConnection(connection);
            var categories = await db.QueryAsync<CategoryDTO>("SELECT * FROM Categories");
            return categories;
        }
    }
}