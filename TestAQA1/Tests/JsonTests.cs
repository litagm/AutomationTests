using AutomationTests.DTO.UsersDataDTO;
using AutomationTests.Utils;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AutomationTests.Tests
{
    internal class JsonTests
    {
        private Root usersData;

        [OneTimeSetUp]
        public void Setup()
        {
            string json = FileReader.ReadJsonFile("Resources", "UsersData.json");
            usersData = JsonSerializer.Deserialize<Root>(json);
        }

        [Test]
        public void Test_2_1() //Проверить, что количество юзеров из файла равно 10
        {
            usersData.data.Count.Should().Be(10);
        }

        [Test]
        public void Test_2_2() //Проверить, что первый юзер - Alice Johnson
        {
            usersData.data.First().profile.fullName.Should().Be("Alice Johnson");
        }

        [Test]
        public void Test_2_3() //Проверить, что все Id уникальны
        {
            var ids = usersData.data.Select(u => u.id).ToList();
            ids.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void Test_2_4() //Проверить, что есть хотя бы один премиум-пользователь
        {
            var hasPremium = usersData.data.Any(u => u.profile.tags != null && u.profile.tags.Contains("premium"));
            hasPremium.Should().BeTrue();
        }

        [Test]
        public void Test_2_5() //Проверить, что у всех юзеров поле город - не пустой
        {
            usersData.data.Should().AllSatisfy(u =>
                u.profile.address.city.Should().NotBeNullOrWhiteSpace());
        }

        [Test]
        public void Test_2_6() //Проверить, что есть хотя бы один пользователь из Стокгольма
        {
            var hasStockholmUser = usersData.data.Any(u => u.profile.address.city == "Stockholm");
            hasStockholmUser.Should().BeTrue();
        }

        [Test]
        public void Test_2_7() //Проверить, что возраст всех юзеров в диапазоне 18-60 лет
        {
            usersData.data.Should().AllSatisfy(u => u.profile.age.Should().BeInRange(18, 60));
        }

        [Test]
        public void Test_2_8() //Проверить, что есть хотя бы один юзер с ролью admin
        {
            var hasAdmin = usersData.data.Any(u => u.roles != null && u.roles.Contains("admin"));
            hasAdmin.Should().BeTrue();
        }

        [Test]
        public void Test_3() //Проверить, что все юзеры (их координаты) находятся в диапазоне Швеции
        {
            usersData.data.Should().AllSatisfy(u =>
            {
                u.profile.address.geo.lat.Should().BeInRange(55.0, 69.0);
                u.profile.address.geo.lng.Should().BeInRange(11.0, 24.0);
            });
        }

        [Test]
        public void Test_4() //Проверить, что улицы у юзеров соответствуют условиям: содержат номер дома, улица начинается с буквы, улица не состоит только из цифр
        {
            usersData.data.Should().AllSatisfy(u =>
            {
                var street = u.profile.address.street;

                char.IsLetter(street[0]).Should().BeTrue();

                street.All(char.IsDigit).Should().BeFalse();

                street.Any(char.IsDigit).Should().BeTrue();
            });
        }

    }
}
