using Agrogar.Shared.DTOs;

namespace Agrogar.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegisterDTO request);
        Task<ServiceResponse<string>> Login(UserLoginDTO request);
        Task<ServiceResponse<UserProfileDTO>> GetUser(int userId);
    }
}
