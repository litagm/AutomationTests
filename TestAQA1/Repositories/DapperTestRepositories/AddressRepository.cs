using AutomationTests.DTO.DapperTestsDTO;
using AutomationTests.Interfaces.DapperTestsInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using AutomationTests.DTO.DapperTestsDTO;
using AutomationTests.Interfaces.DapperTestsInterfaces;

namespace AutomationTests.Repositories.DapperTestRepositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string connection;
        public AddressRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<AddressDTO> GetAddressByUserId(int userId)
        {
            using var db = new SqliteConnection(connection);
            var address = await db.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * from Addresses " +
                "WHERE UserId = @userId", new { userId });
            return address;
        }
    }
}
