using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AutomationTests.DTO.FirstTestDTO;
using Tests1.Interfaces;


namespace Tests1.Tests
{
    public class RefitTests
    {
        private IUserApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://reqres.in/api");
            });

            var provider = services.BuildServiceProvider();

            api = provider.GetRequiredService<IUserApi>();
        }

        [Test]
        public async Task Test1() //Проверяет GET-запрос — получение юзера (id: 2) и соответствие его ID
        {
            var result = await api.GetUserAsync(2);
            Assert.That(result.Data.ID, Is.EqualTo(2));
        }

        [Test]
        public async Task Test2() //Проверяет POST-запрос — создание юзера ("John", "Apple") и корректность ответа
        {
            var request = new CreateUserRequestDTO { Name = "John", Job = "Apple" };
            var response = await api.CreateUserAsync(request);
            Assert.That(response.Name, Is.EqualTo("John"));
            Assert.That(response.Job, Is.EqualTo("Apple"));
        }

        [Test]
        public async Task Test3() //Проверяет DELETE-запрос — удаление юзера (id: 2) и статус 204 NoContent
        {
            var deleteResult = await api.DeleteUserAsync(2);
            Assert.That(deleteResult.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            //Assert.That((int)deleteResult.StatusCode, Is.EqualTo(204));
        }

        [Test]
        public async Task Test4() //Проверяет PUT-запрос — обновление данных юзера (id: 2) на ("Mark", "QA") и корректность ответа
        {
            {
                var request = new CreateUserRequestDTO { Name = "Mark", Job = "QA" };
                var response = await api.UpdateUserAsync(2, request); // Убедитесь, что метод в интерфейсе назван именно UpdateUserAsync
                Assert.That(response.Job, Is.EqualTo("QA"));
            }
        } 

    }
}