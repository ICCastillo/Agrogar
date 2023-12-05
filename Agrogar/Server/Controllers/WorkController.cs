using Agrogar.Shared.DTOs;
using Agrogar.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Agrogar.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkController : ControllerBase
	{
		private readonly IWorkService _workService;
		private readonly IWorkAssemblyService _workassemblyService;
		public WorkController(IWorkService workService, IWorkAssemblyService workassemblyService)
		{
			_workService = workService;
			_workassemblyService = workassemblyService;
		}

		
        [HttpGet("all/{propertyId}")]
        public async Task<ActionResult<ServiceResponse<List<WorkDTO>>>> GetWorks(int propertyId)
        {
            var result = await _workassemblyService.GetAllWorks(propertyId);
            return Ok(result);
        }

        [HttpGet("{workId}")]
		public async Task<ActionResult<ServiceResponse<WorkDTO>>> GetWork(int workId)
		{
			var result = await _workassemblyService.GetWork(workId);
			return Ok(result);
		}

		[HttpPost("register")]
		public async Task<ActionResult<ServiceResponse<int>>> Register(WorkAssignmentRegisterDTO workAssignmentRegisterDTO)
		{
			List<Assignment> assignments = new List<Assignment>();
			foreach(var assignment in workAssignmentRegisterDTO.Assignments)
			{
				var newAssignment = new Assignment
				{
					JobTitle = assignment.JobTitle,
					LicensePP = assignment.LicensePP,
					IsCompleted = false,
					IsAvailable = true
				};
				assignments.Add(newAssignment);
			}

			var response = await _workService.Register(new Work
			{
				PropertyId = workAssignmentRegisterDTO.Work.PropertyId,
				TaskTypeId = workAssignmentRegisterDTO.Work.TaskTypeId,
				StartDate = workAssignmentRegisterDTO.Work.StartDate,
				EndDate = workAssignmentRegisterDTO.Work.EndDate,
				Details = workAssignmentRegisterDTO.Work.Details,
				IsActive = true
			}, assignments
			);

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpPut("complete/{workId}")]
		public async Task<ActionResult<ServiceResponse<int>>> Complete(int workId)
		{
			var response = await _workService.Complete(workId);
			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}
	}
}
