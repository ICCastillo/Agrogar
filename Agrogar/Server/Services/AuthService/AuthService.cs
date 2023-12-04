using Agrogar.Server.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Agrogar.Server.Services.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly DataContext _context;
		private readonly IConfiguration _configuration;

		public AuthService(DataContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public DataContext Context { get; }

		public async Task<ServiceResponse<string>> Login(string email, string password)
		{
			var response = new ServiceResponse<string>();
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
			if (user == null)
			{
				response.Success = false;
				response.Message = "No se encontro el usuario.";
			}
			else if(!VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
			{
				response.Success = false;
				response.Message = "Contraseña incorrecta.";
			}
			else
			{
				response.Data = CreateToken(user);
			}
			
			return response;
		}

		public async Task<ServiceResponse<int>> Register(User user, string password)
		{
			if(await UserExists(user.Email))
			{
				return new ServiceResponse<int> { Success = false, Message = "El usuario ya existe." };
			}

			CreatePassswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;
			
			_context.Add(user);
			
			await _context.SaveChangesAsync();
			
			return new ServiceResponse<int> { Data = user.Id ,Success = true, Message = "El usuario se registro correctamente." };
		
		}

		public async Task<bool> UserExists(string email)
		{
			if(await _context.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower())))
			{
				return true;
			}
			return false;
		}

		private void CreatePassswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using(var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
		{
			using(var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash.SequenceEqual(passwordHash);
			}
		}

		private string CreateToken(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
			};

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}

        public async Task<ServiceResponse<User>> GetUser(int userId)
        {
            var response = new ServiceResponse<User>();
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                response.Success = false;
                response.Message = "No existe este usuario.";
            }
            else
            {
                response.Data = user;
            }

            return response;
        }
    }
}
