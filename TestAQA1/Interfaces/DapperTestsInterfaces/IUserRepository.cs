using AutomationTests.DTO.DapperTestsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using AutomationTests.DTO.DapperTestsDTO;

namespace AutomationTests.Interfaces.DapperTestsInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByNameAndSurname(string firstName, string lastName);
    }
}
