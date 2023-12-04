using Agrogar.Shared;


namespace Agrogar.Server.Services.JobPositionService
{
	public class JobTitleService : IJobTitleService
	{
		private readonly DataContext _context;
		public JobTitleService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<JobTitle>>> GetJobTitles()
		{
			var jobTitles = await _context.JobTitles.ToListAsync();
			return new ServiceResponse<List<JobTitle>>
			{
				Data = jobTitles
            };
		}
	}
}
