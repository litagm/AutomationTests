using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutomationTests.DTO.UsersDataDTO
{
    public record Datum(
           [property: JsonPropertyName("id")] int id,
           [property: JsonPropertyName("username")] string username,
           [property: JsonPropertyName("profile")] Profile profile,
           [property: JsonPropertyName("roles")] IReadOnlyList<string> roles
       );


}
