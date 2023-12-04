using System.Net.Http.Json;
using Agrogar.Shared.DTOs;

namespace Agrogar.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<ServiceResponse<string>> Login(UserLoginDTO request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<UserProfileDTO>> GetUser(int userId)
        {
			return await _httpClient.GetFromJsonAsync<ServiceResponse<UserProfileDTO>>($"api/auth/get/{userId}");
        }
    }
}
