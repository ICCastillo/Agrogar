using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared.DTOs
{
	public class AssignmentDTO
	{
		public int Id { get; set; }
		public int? UserId { get; set; }
		public string JobTitle { get; set; }
		public bool IsCompleted { get; set; }
		public bool IsAvailable { get; set; }
		public string Comments { get; set; }
		public int? WorkedHours { get; set; }
		public DateTime? DateCompleted { get; set; }
		public bool LicensePP { get; set; }
		public int WorkId { get; set; }
		public WorkDTO Work { get; set; }
	}
}
