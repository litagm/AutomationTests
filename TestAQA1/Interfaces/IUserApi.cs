
using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using AutomationTests.DTO.FirstTestDTO;


namespace AutomationTests.Interfaces
{
    [Headers("x-api-key: free_user_3IJZWznUMiXWMH5pK9fwL6ouONU")]
    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<UserResponseDTO> GetUserAsync(int id);

        [Post("/users")]
        Task<CreateUserResponseDTO> CreateUserAsync([Body] CreateUserRequestDTO request);

        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);

        [Put("/users/{id}")]
        Task<CreateUserResponseDTO> UpdateUserAsync(int id, [Body] CreateUserRequestDTO user);
    }
}
