using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TesAutomationTeststs1.DTO.DapperTestsDTO
{
    public record OrderDTO
        (
        long id,

        long userId,

        string orderDate,

        string status,

        double totalPrice
        );
}