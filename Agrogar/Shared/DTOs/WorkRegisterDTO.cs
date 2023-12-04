using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared.DTOs
{
	public class WorkRegisterDTO
	{
        [Required]
		public int PropertyId { get; set; }
		[Required]
		public int TaskTypeId { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		public string? Details { get; set; }
	}
}
