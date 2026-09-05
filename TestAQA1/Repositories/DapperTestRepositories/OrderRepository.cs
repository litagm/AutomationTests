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

        public async Task<bool> DoAllTvBuyersBuyAccessoriesAsync()
        {
            using var db = new SqliteConnection(connection);

            const string sql = @"
        SELECT COUNT(1)
        FROM (
            SELECT DISTINCT o.UserId
            FROM Orders o
            JOIN OrderItems oi ON o.Id = oi.OrderId
            JOIN Products p ON oi.ProductId = p.Id
            JOIN Categories c ON p.CategoryId = c.Id
            WHERE c.Name = 'Телевизоры'
        ) tv_buyers
        INNER JOIN (
            SELECT DISTINCT o.UserId
            FROM Orders o
            JOIN OrderItems oi ON o.Id = oi.OrderId
            JOIN Products p ON oi.ProductId = p.Id
            JOIN Categories c ON p.CategoryId = c.Id
            WHERE c.Name = 'Аксессуары'
        ) acc_buyers ON tv_buyers.UserId = acc_buyers.UserId;";

            var matchingBuyersCount = await db.ExecuteScalarAsync<int>(sql);
            return matchingBuyersCount > 0;
        }
    }
}