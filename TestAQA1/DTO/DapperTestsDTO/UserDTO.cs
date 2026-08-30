using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using AutomationTests.DTO.UsersDataDTO;

namespace AutomationTests.DTO.DapperTestsDTO
{
    public record UserDTO
        (
        long id,

        string firstName,

        string lastName,

        string email,

        string phone,

        string createdAt
        );
}
