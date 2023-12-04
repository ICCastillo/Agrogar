namespace Agrogar.Server.Services.JobPositionService
{
	public interface IJobTitleService
	{
		Task<ServiceResponse<List<JobTitle>>> GetJobTitles();
	}
}
