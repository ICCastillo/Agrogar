using Agrogar.Server.Data;
using Agrogar.Shared;
using Agrogar.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.NetworkInformation;

namespace Agrogar.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PropertyController : ControllerBase
	{
		private readonly IPropertyService _propertyService;
		private readonly IPropertyAssemblyService _propertyAssemblyService;
		
        public PropertyController(IPropertyService propertyService, IPropertyAssemblyService propertyBuilderService)
		{
			_propertyService = propertyService;
			_propertyAssemblyService = propertyBuilderService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<PropertyDTO>>>> GetProperties()
		{
			var result = await _propertyAssemblyService.GetAllProperties();
			return Ok(result);
		}

		[HttpGet("{propertyId}")]
		public async Task<ActionResult<ServiceResponse<PropertyDTO>>> GetPropertyById(int propertyId)
		{
			var result = await _propertyAssemblyService.GetProperty(propertyId);
			return Ok(result);
		}

        [HttpGet("get/{userId}")]
        public async Task<ActionResult<ServiceResponse<PropertyDTO>>> GetPropertiesByUserId(int userId)
        {
            var result = await _propertyAssemblyService.GetPropertiesByUserId(userId);
            return Ok(result);
        }

        [HttpPost("register")]
		public async Task<ActionResult<ServiceResponse<int>>> Register(PropertyRegisterDTO request)
		{
			var response = await _propertyService.Register(new Property
			{
                CadasterReference = request.CadasterReference,
                Province = request.Province,
                Municipality = request.Municipality,
                UserId = request.UserId,
                Crop = request.Crop,
                WorkPhaseId = request.WorkPhaseId,
                CategoryId = request.CategoryId,
                Size = request.Size
            });

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpDelete("{propertyId}")]
		public async Task<ActionResult<ServiceResponse<int>>> Delete(int propertyId)
		{
			var response = await _propertyService.DeleteProperty(propertyId);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPut("update/{propertyId}/{workPhaseId}")]
		public async Task<ActionResult<ServiceResponse<int>>> Update(int propertyId, int workPhaseId)
		{
			var response = await _propertyService.UpdateProperty(propertyId, workPhaseId);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		
	}
}
