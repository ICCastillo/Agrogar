using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace Agrogar.Shared
{
	public class Work
	{
		[Key]
        public int Id { get; set; }
		[ForeignKey("PropertyId")]
		public int PropertyId { get; set; }
		public Property Property { get; set; }
		[ForeignKey("TaskTypeId")]
		public int TaskTypeId { get; set; }
		public TaskType TaskType { get; set; }
		public string? Details { get; set; }
		public bool IsActive { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
