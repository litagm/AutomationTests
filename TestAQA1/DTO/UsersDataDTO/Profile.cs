using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.UsersDataDTO
{
    public record Profile(
           [property: JsonPropertyName("fullName")] string fullName,
           [property: JsonPropertyName("age")] int age,
           [property: JsonPropertyName("address")] Address address,
           [property: JsonPropertyName("tags")] IReadOnlyList<string> tags
       );

}
