using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.UsersDataDTO
{
    public record Geo(
            [property: JsonPropertyName("lat")] double lat,
            [property: JsonPropertyName("lng")] double lng
        );

}
