namespace Agrogar.Server.Services.WorkService
{
	public interface IWorkService
	{
		Task<ServiceResponse<List<Work>>> GetWorks(int propertyId);
		Task<ServiceResponse<Work>> GetWork(int workId);
		Task<ServiceResponse<int>> Register(Work work, List<Assignment> assignment);
		Task<ServiceResponse<int>> Complete(int workId);
	}
}
