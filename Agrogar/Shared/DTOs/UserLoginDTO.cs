using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Agrogar.Shared.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
		[Required, StringLength(100, MinimumLength = 8)]
		public string Password { get; set; }
    }
}
