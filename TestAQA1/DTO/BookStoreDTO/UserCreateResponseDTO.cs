using AutomationTests.DTO.BookStoreDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTests.DTO.BookStoreDTO
{
    public record UserCreateResponseDTO(
        string UserId,
        string UserName,
        List<UserCreateResponseBookDTO> Books
    );
}
