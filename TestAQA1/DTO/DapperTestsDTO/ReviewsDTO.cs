using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.DapperTestsDTO
{
    public record ReviewsDTO
        (
        long id,

        string userId,

        string productId,

        long rating,

        long comment,

        long createdAt
        );
}