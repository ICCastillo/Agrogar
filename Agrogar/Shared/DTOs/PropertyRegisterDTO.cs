using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared.DTOs
{
	public class PropertyRegisterDTO
	{
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Municipality { get; set; }
        [Required]
        public string CadasterReference { get; set; }
        [Required]
        public int WorkPhaseId { get; set; }
        [Required]
        public string Crop { get; set; }
        [Required]
        public int Size { get; set; }
    }
}
