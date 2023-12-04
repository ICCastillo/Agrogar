using Agrogar.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WorkAssignmentRegisterDTO
{
	public WorkRegisterDTO Work { get; set; }
	public List<AssignmentRegisterDTO> Assignments { get; set; }
}
