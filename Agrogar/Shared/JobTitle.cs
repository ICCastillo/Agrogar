using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrogar.Shared
{
	public class JobTitle
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
