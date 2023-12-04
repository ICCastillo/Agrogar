using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrogar.Shared
{
	public class Property
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("UserId")]
		public int UserId { get; set; }
		public User User { get; set; }
		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		[ForeignKey("WorkPhaseId")]
		public int WorkPhaseId { get; set; }
		public WorkPhase WorkPhase { get; set; }
		public string Province { get; set; }
		public string Municipality { get; set; }
		public string CadasterReference { get; set; }
		public int Size { get; set; }
        public string Crop { get; set; }
	}
}
