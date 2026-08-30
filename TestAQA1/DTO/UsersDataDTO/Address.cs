using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.UsersDataDTO
{
    public record Address(
         [property: JsonPropertyName("street")] string street,
         [property: JsonPropertyName("city")] string city,
         [property: JsonPropertyName("geo")] Geo geo
     );
}
