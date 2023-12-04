using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared.DTOs
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string Coordenates { get; set; }
        public string Address { get; set; }
        public string CadasterReference { get; set; }
        public WorkPhase WorkPhase { get; set; }
        public string Crop {  get; set; }
        public int Size { get; set; }
        public List<WorkDTO> Works { get; set; } = new List<WorkDTO>();
        public bool ShowDetails { get; set; }
    }
}
