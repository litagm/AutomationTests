using System.Text.Json.Serialization;

namespace AutomationTests.DTO.FirstTestDTO
{
    public class CreateUserResponseDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("job")]
        public string Job { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

    }
}