using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using AutomationTests.Utils;
using AutomationTests.DTO;
using AutomationTests.Interfaces;
using AutomationTests.Preconditions;
using AutomationTests.Interfaces.DapperTestsInterfaces;
using FluentAssertions;

namespace AutomationTests.Tests
{
    public class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();

        [Test]
        public async Task Test001CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task Test002GetUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByIdAsync(15);
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test003GetUserByNameAndSurname()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByNameAndSurname("Мария", "Павлова");
            users.Should().NotBeNull();
            users.firstName.Should().Be("Мария");
            users.lastName.Should().Be("Павлова");
        }

        [Test]
        public async Task Test004GetAddressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo.GetAddressByUserId(1);
            address.Should().NotBeNull();
        }


        [Test] //генерация базы - раскомментить, а потом запустить тест разово
        public async Task InitialiseTest()
        {
            var connectionString = "Data Source=marketplace.db";
            await using var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();
            await DatabaseInitializer.InitializeAsync(connection);
        }
    }
}
