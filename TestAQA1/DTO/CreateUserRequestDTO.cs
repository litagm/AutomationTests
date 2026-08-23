using System.Text.Json.Serialization;

namespace Test
{
    public class CreateUserRequestDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}
