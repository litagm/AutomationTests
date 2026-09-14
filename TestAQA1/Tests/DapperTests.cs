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
using System.Linq;

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


        //[Test] //генерация базы - раскомментить, а потом запустить тест разово
        //public async Task InitialiseTest()
        //{
        //var connectionString = "Data Source=marketplace.db";
        //await using var connection = new SqliteConnection(connectionString);
        //await connection.OpenAsync();
        // await DatabaseInitializer.InitializeAsync(connection);
        //}

        [Test]
        public async Task Test21CheckAllCategoriesCount()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategoriesAsync();

            categories.Should().HaveCount(6);
        }

        [Test]
        public async Task Test22GetProductByIdAndCheckFields()
        {
            var repo = p.Provider.GetService<IProductRepository>();

            var product = await repo.GetProductByIdAsync(13);

            product.Should().NotBeNull();
            product.name.Should().Be("Philips Airfryer");
            product.description.Should().Be("Аэрогриль Philips");
            product.price.Should().Be(12990);
            product.stock.Should().Be(20);
            product.categoryId.Should().Be(5);
        }

        [Test]
        public async Task Test23GetUserOrderWithItems()
        {
            var repo = p.Provider.GetService<IOrderRepository>();

            var order = await repo.GetOrderByIdAndUserIdAsync(8, 8);

            order.Should().NotBeNull();
            order.userId.Should().Be(8);
            order.orderDate.Should().Be("2026-03-12");
            order.status.Should().Be("Processing");
            order.totalPrice.Should().Be(42990);

            var items = (await repo.GetOrderItemsWithProductsByOrderIdAsync(8)).ToList();

            items.Should().NotBeNullOrEmpty();
            items.Should().HaveCount(1);

            var item = items.First();
            item.productId.Should().Be(14);
            item.quantity.Should().Be(1);
            item.unitPrice.Should().Be(42990);
        }

        [Test]
        public async Task Test24CheckAccessoriesBoughtByUsersFromDifferentCities()
        {
            var repo = p.Provider.GetService<IAddressRepository>();

            var cities = (await repo.GetCitiesByCategoryNameAsync("Аксессуары")).ToList();

            cities.Should().NotBeNullOrEmpty();
            cities.Distinct().Count().Should().BeGreaterThan(1);
        }

        [Test]
        public async Task Test25CheckTvBuyersAlsoBuyAccessories()
        {
            var repo = p.Provider.GetService<IOrderRepository>();

            var result = await repo.DoAllTvBuyersBuyAccessoriesAsync();

            result.Should().BeTrue();
        }

    }
}
