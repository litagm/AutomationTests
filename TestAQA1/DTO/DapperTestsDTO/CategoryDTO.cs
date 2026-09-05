using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.DapperTestsDTO
{
    public record CategoryDTO
        (
        long id,

        string name
        );
}
