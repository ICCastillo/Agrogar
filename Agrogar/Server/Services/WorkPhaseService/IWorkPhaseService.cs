namespace Agrogar.Server.Services.WorkPhaseService
{
	public interface IWorkPhaseService
	{
		Task<ServiceResponse<List<WorkPhase>>> GetWorkPhases();
	}
}
