using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Agrogar.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkPhaseController : ControllerBase
	{
		private readonly IWorkPhaseService _workPhaseService;
		public WorkPhaseController(IWorkPhaseService workPhaseService)
		{
			_workPhaseService = workPhaseService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<WorkPhase>>>> GetCategories()
		{
			var result = await _workPhaseService.GetWorkPhases();
			return Ok(result);
		}

	}
}
