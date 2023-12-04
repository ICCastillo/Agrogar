using Agrogar.Shared;

namespace Agrogar.Server.Services.TaskTypeService
{
	public class TaskTypeService : ITaskTypeService
	{
		private readonly DataContext _context;
		public TaskTypeService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<TaskType>>> GetTaskTypes()
		{
			var taskTypes = await _context.TaskType.ToListAsync();
			return new ServiceResponse<List<TaskType>>
			{
				Data = taskTypes
			};
		}
	}
}
