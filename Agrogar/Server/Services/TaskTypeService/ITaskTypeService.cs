namespace Agrogar.Server.Services.TaskTypeService
{
	public interface ITaskTypeService
	{
		Task<ServiceResponse<List<TaskType>>> GetTaskTypes();
	}
}
