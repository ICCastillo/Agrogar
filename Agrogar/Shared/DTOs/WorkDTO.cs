using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared.DTOs
{
    public class WorkDTO
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
        public List<AssignmentDTO> Assignments { get; set; } = new List<AssignmentDTO>();
        public PropertyDTO Property { get; set; }
    }
}
