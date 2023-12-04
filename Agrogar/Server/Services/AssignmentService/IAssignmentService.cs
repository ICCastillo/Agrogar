namespace Agrogar.Server.Services.AssignmentService
{
	public interface IAssignmentService
	{
		Task<ServiceResponse<List<Assignment>>> GetAssignmentsByWorkId(int workId);
        Task<ServiceResponse<List<Assignment>>> GetAssignmentsByUserId(int userId);
        Task<ServiceResponse<Assignment>> GetAssignment(int assignmentId);
		Task<ServiceResponse<int>> Update(int assignmentId, int userId);
		Task<ServiceResponse<int>> Complete(int assignmentId, int workedHours, string comments);
	}
}
