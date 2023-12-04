using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Agrogar.Shared
{
	public class Assignment
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("UserId")]
		public int? UserId { get; set; }
		public User User { get; set; }
		[ForeignKey("WorkId")]
		public int WorkId { get; set; }
		public Work Work { get; set; }
		public string JobTitle { get; set; }
        public bool LicensePP { get; set; }
        public bool IsCompleted { get; set; }
		public bool IsAvailable { get; set; }
		public string? Comments { get; set; }
		public int? WorkedHours { get; set; }
		public DateTime? DateCompleted { get; set; }
	}
}
