using Agrogar.Shared;
using Agrogar.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Agrogar.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssignmentController : ControllerBase
	{
		private readonly IAssignmentService _assignmentService;
		public AssignmentController(IAssignmentService assignmentService)
		{
			_assignmentService = assignmentService;
		}

		[HttpGet("workId")]
		public async Task<ActionResult<ServiceResponse<List<AssignmentDTO>>>> GetAssignmentsByWorkId(int workId)
		{
			var result = await _assignmentService.GetAssignmentsByWorkId(workId);
			return Ok(result);
		}

        [HttpGet("get/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<AssignmentDTO>>>> GetAssignmentsByUserId(int userId)
        {
            var result = await _assignmentService.GetAssignmentsByUserId(userId);
			List<AssignmentDTO> assignments = new List<AssignmentDTO>();
			ServiceResponse<List<AssignmentDTO>> response = new ServiceResponse<List<AssignmentDTO>>();
			foreach (var assignment in result.Data)
			{
				assignments.Add(new AssignmentDTO
				{
					Id = assignment.Id,
					JobTitle = assignment.JobTitle,
					IsCompleted = assignment.IsCompleted,
					Comments = assignment.Comments,
					WorkedHours = assignment.WorkedHours,
					DateCompleted = assignment.DateCompleted,
					LicensePP = assignment.LicensePP,
					WorkId = assignment.WorkId,
					UserId = assignment.UserId,
					IsAvailable = assignment.IsAvailable
				});
			}
			response.Data = assignments;
            return Ok(response);
        }

        [HttpGet("{assignmentId}")]
		public async Task<ActionResult<ServiceResponse<AssignmentDTO>>> GetProperty(int assignmentId)
		{
			var result = await _assignmentService.GetAssignment(assignmentId);
			return Ok(result);
		}

		[HttpPut("update/{assignmentId}/{userId}")]
		public async Task<ActionResult<ServiceResponse<int>>> Update(int assignmentId, int userId)
		{
			var response = await _assignmentService.Update(assignmentId, userId);

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpPut("complete/{assignmentId}/{workedHours}/{comments}")]
		public async Task<ActionResult<ServiceResponse<int>>> Complete(int assignmentId, int workedHours, string comments)
		{
			var response = await _assignmentService.Complete(assignmentId, workedHours, comments);

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}
	}
}
