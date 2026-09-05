using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.DapperTestsDTO
{
    public record ProductDTO
        (
        long id,

        string name,

        string description,

        double price,

        long stock,

        long categoryId
        );
}