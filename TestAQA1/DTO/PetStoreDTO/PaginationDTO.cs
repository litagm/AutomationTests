using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomationTests.DTO.PetStoreDTO
{
    public record PaginationDTO(
        int Page,
        int Limit,
        int TotalItems,
        int TotalPages
    );
}
