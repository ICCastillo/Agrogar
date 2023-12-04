using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrogar.Shared
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public string PhoneNumber { get; set; }
		public bool LicensePP { get; set; }

	}
}
