using Agrogar.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agrogar.Client.Services.DataService
{
	public class DataService : IDataService
	{
		private readonly HttpClient _http;
		public IDataStorageService _storageService;

		public DataService(HttpClient http, IDataStorageService storageService)
		{
			_http = http;
			_storageService = storageService;
		}

		private async Task<ServiceResponse<List<Category>>> GetCateogries()
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
			return result;
		}

		private async Task<ServiceResponse<List<JobTitle>>> GetJobTitles()
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<List<JobTitle>>>("api/jobTitle");
			return result;
		}

		private async Task<ServiceResponse<List<TaskType>>> GetTaskTypes()
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<List<TaskType>>>("api/taskType");
			return result;
		}

		private async Task<ServiceResponse<List<WorkPhase>>> GetWorkPhases()
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<List<WorkPhase>>>("api/workPhase");
			return result;
		}

		private async Task<ServiceResponse<Dictionary<WorkPhase, List<TaskType>>>> GetWorkPhasesAndTasks()
		{
			ServiceResponse<Dictionary<WorkPhase, List<TaskType>>> WorkPhasesAndTasks = new ServiceResponse<Dictionary<WorkPhase, List<TaskType>>>();
			var taskTypes = await GetTaskTypes();
			var workPhases = await GetWorkPhases();
			if(taskTypes != null && workPhases != null)
			{
				WorkPhasesAndTasks.Data = workPhases.Data.ToDictionary(wp => wp, wp => taskTypes.Data
                                          .Where(tt => tt.WorkPhaseId == wp.Id).ToList());
            }
			else
			{
                WorkPhasesAndTasks.Success = false;
			}

			return WorkPhasesAndTasks;
        }

		public async Task FillConstantCollections()
		{
			var categories = await GetCateogries();
			var jobTitles = await GetJobTitles();
			var workPhasesAndTasks = await GetWorkPhasesAndTasks();

			if(workPhasesAndTasks.Success && categories.Success && jobTitles.Success)
			{
				_storageService.WorkPhasesAndTasks = workPhasesAndTasks.Data;
				_storageService.JobTitles = jobTitles.Data;
				_storageService.Categories = categories.Data;
			}

		}
	}

}
