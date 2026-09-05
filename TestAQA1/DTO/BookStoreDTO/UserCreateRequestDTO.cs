using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTests.DTO.BookStoreDTO
{
    public record UserCreateRequestDTO(
        string UserName,
        string Password
    );
}
