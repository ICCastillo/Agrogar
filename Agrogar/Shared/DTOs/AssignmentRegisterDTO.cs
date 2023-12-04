using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared.DTOs
{
	public class AssignmentRegisterDTO
	{
		[Required] 
		public int UserId { get; set; }
		[Required]
		public string JobTitle { get; set; }
		[Required]
		public bool LicensePP { get; set; }
		

	}
}
