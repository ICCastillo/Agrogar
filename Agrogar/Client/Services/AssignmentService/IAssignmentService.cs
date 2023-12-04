namespace Agrogar.Client.Services.AssignmentService
{
    public interface IAssignmentService
    {
        Task<ServiceResponse<List<AssignmentDTO>>> GetAssignmentsByWorkId(int workId);
        Task<ServiceResponse<List<AssignmentDTO>>> GetAssignmentsByUserId(int userId);
        Task<ServiceResponse<AssignmentDTO>> GetAssignment(int assignmentId);
        Task<ServiceResponse<int>> Update(int assignmentId, int userId);
		Task<ServiceResponse<int>> Complete(int assignmentId, int workedHours, string comments);
	}
}
