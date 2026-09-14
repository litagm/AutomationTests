using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Refit;
using AutomationTests.DTO.PetStoreDTO;
using AutomationTests.Interfaces.PetStoreInterfaces;

namespace AutomationTests.Interfaces.PetStoreInterfaces
{
    public interface IPetApi
    {
        [Get("/pets")]
        Task<RootDTO> GetAllPetsAsync();

        [Get("/pets")]
        Task<RootDTO> GetAllPetsByMinAgeAndLimit100Async([Query] int minAge, [Query] int limit);

        [Get("/pets/{id}")]
        Task<PetDTO> GetPetByIdAsync(string id);
    }
}
