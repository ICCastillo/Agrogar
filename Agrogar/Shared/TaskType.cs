using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared
{
	public class TaskType
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[ForeignKey("WorkPhaseId")]
		public int WorkPhaseId { get; set; }
		public WorkPhase WorkPhase { get; set; }
	}
}
