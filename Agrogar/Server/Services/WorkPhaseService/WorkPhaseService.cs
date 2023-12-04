using Agrogar.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Agrogar.Server.Services.WorkPhaseService
{
	public class WorkPhaseService : IWorkPhaseService
	{
		private readonly DataContext _context;
		public WorkPhaseService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<WorkPhase>>> GetWorkPhases()
		{
			var categories = await _context.WorkPhase.ToListAsync();
			return new ServiceResponse<List<WorkPhase>>
			{
				Data = categories
			};
		}
	}
}
