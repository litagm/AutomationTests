using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTests.DTO.BookStoreDTO
{
    public record UserCreateResponseBookDTO(
        string Isbn,
        string Title,
        string SubTitle,
        string Author,
        string PublishDate,
        string Publisher,
        int Pages,
        string Description,
        string Website
    );
}
