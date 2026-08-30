using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.UsersDataDTO
{
    public record Root(
       [property: JsonPropertyName("data")] IReadOnlyList<Datum> data
   );
}
