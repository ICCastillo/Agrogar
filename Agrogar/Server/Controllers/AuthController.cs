using Agrogar.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agrogar.Server.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService) 
		{
			_authService = authService; 
		}

		[HttpPost("register")]
		public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO request)
		{
			
			var response = await _authService.Register(new User {Email = request.Email, 
																 Name = request.Name, 
																 PhoneNumber = request.PhoneNumber,
																 LicensePP = request.LicensePP}, request.Password);

			if(!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpPost("login")]
		public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO request)
		{
			var response = await _authService.Login(request.Email, request.Password);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

        [HttpGet("get/{userId}")]
        public async Task<ActionResult<ServiceResponse<UserProfileDTO>>> GetUser(int userId)
        {
            var result = await _authService.GetUser(userId);
			var user = result.Data;
			UserProfileDTO userProfileDTO = new UserProfileDTO();
			userProfileDTO.Name = user.Name;
            userProfileDTO.PhoneNumber = user.PhoneNumber;
			userProfileDTO.Email = user.Email;
			userProfileDTO.Created = user.DateCreated;
			userProfileDTO.LicensePP = user.LicensePP;
			ServiceResponse<UserProfileDTO> response = new ServiceResponse<UserProfileDTO>();
			response.Data = userProfileDTO;
            return Ok(response);
        }
    }
}
