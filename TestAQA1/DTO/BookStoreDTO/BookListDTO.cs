using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTests.DTO.BookStoreDTO
{
    public record BookListDTO(
        List<UserCreateResponseBookDTO> Books);

}
