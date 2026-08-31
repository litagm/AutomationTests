using AutomationTests.DTO.DapperTestsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesAutomationTeststs1.DTO.DapperTestsDTO;
using Tests1.DTO.DapperTestsDTO;

namespace AutomationTests.Interfaces.DapperTestsInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderDTO> GetOrderByIdAndUserIdAsync(int orderId, int userId);
        Task<IEnumerable<OrderItemsDTO>> GetOrderItemsWithProductsByOrderIdAsync(int orderId);
    }
}