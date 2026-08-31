using AutomationTests.DTO.DapperTestsDTO;
using AutomationTests.Interfaces.DapperTestsInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesAutomationTeststs1.DTO.DapperTestsDTO;
using Tests1.DTO.DapperTestsDTO;

namespace AutomationTests.Repositories.DapperTestRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connection;

        public OrderRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<OrderDTO> GetOrderByIdAndUserIdAsync(int orderId, int userId)
        {
            using var db = new SqliteConnection(connection);

            const string sql = @"
                SELECT 
                    Id AS id, 
                    UserId AS userId, 
                    OrderDate AS orderDate, 
                    Status AS status, 
                    TotalPrice AS totalPrice 
                FROM Orders 
                WHERE Id = @orderId AND UserId = @userId;";

            var order = await db.QueryFirstOrDefaultAsync<OrderDTO>(sql, new { orderId = orderId, userId = userId });
            return order;
        }

        public async Task<IEnumerable<OrderItemsDTO>> GetOrderItemsWithProductsByOrderIdAsync(int orderId)
        {
            using var db = new SqliteConnection(connection);

            const string sql = @"
                SELECT 
                    Id AS id, 
                    OrderId AS orderId, 
                    ProductId AS productId, 
                    Quantity AS quantity, 
                    UnitPrice AS unitPrice 
                FROM OrderItems 
                WHERE OrderId = @orderId;";

            var items = await db.QueryAsync<OrderItemsDTO>(sql, new { orderId = orderId });
            return items;
        }
    }
}