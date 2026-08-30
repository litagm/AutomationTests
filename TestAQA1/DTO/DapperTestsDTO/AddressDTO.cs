using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.DapperTestsDTO
{
    public record AddressDTO
        (
        long id,

        long userId,

        string city,

        string street,

        string house,

        string apartment
        );

}
