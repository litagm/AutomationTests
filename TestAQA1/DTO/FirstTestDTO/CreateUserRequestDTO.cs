using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.FirstTestDTO
{
    public class CreateUserRequestDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}
