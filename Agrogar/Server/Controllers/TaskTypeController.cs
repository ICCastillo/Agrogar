using Microsoft.AspNetCore.Mvc;

namespace Agrogar.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskTypeController : ControllerBase
	{
		private readonly ITaskTypeService _taskTypeService;
		public TaskTypeController(ITaskTypeService taskTypeService)
		{
			_taskTypeService = taskTypeService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<TaskType>>>> GetTaskTypes()
		{
			var result = await _taskTypeService.GetTaskTypes();
			return Ok(result);
		}

	}

}
