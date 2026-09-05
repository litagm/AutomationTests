using AutomationTests.DTO.DapperTestsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using AutomationTests.DTO.DapperTestsDTO;

namespace AutomationTests.Interfaces.DapperTestsInterfaces
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserId(int userId);
        Task<IEnumerable<string>> GetCitiesByCategoryNameAsync(string categoryName);
    }
}
