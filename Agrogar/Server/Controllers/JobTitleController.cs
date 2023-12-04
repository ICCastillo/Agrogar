using Microsoft.AspNetCore.Mvc;

namespace Agrogar.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobTitleController : ControllerBase
	{
		private readonly IJobTitleService _jobTitleService;
		public JobTitleController(IJobTitleService jobTitleService)
		{
            _jobTitleService = jobTitleService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<JobTitle>>>> GetJobTitles()
		{
			var result = await _jobTitleService.GetJobTitles();
			return Ok(result);
		}

	}
}
