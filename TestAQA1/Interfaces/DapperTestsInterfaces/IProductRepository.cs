using System.Threading.Tasks;
using AutomationTests.DTO.DapperTestsDTO;

namespace AutomationTests.Interfaces.DapperTestsInterfaces
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetProductByIdAsync(int id);
    }
}