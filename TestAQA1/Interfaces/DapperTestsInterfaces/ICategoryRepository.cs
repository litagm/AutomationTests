using System.Collections.Generic;
using System.Threading.Tasks;
using AutomationTests.DTO.DapperTestsDTO;

namespace AutomationTests.Interfaces.DapperTestsInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    }
}