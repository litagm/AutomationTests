using System.Net.Http.Json;
using System.Text.Json;
using Test;

namespace Test1
{
    public class Tests
    {
        private static HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };
            client.DefaultRequestHeaders.Add("x-api-key", "free_user_3IJZWznUMiXWMH5pK9fwL6ouONU");
        }
        [Test]
        public async Task Test1()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            response.EnsureSuccessStatusCode();
        }
        [Test]
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
            UserDataDTO user = userResponse.Data;


        }

        [Test]
        public async Task Test3()
        {
            var createNewUserRequest = new CreateUserRequestDTO
            {
                Name = "Johan",
                Job = "PO"
            };

            using HttpResponseMessage response = await client.PostAsJsonAsync("users", createNewUserRequest);
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseDTO createdUser = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost);
        }

        [Test]
        public async Task Test4()
        {
            var updateUserRequest = new CreateUserRequestDTO
            {
                Name = "Mark",
                Job = "QA"
            };
            using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", updateUserRequest);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test5()
        {
            using HttpResponseMessage response = await client.DeleteAsync("users/2");
            response.EnsureSuccessStatusCode();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();

        }
    }
}
