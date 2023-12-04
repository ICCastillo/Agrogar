using Agrogar.Client.Services.AssignmentService;
using Agrogar.Shared;

namespace Agrogar.Client.Services.AssignmentService
{
    public class AssignmentService : IAssignmentService
    {
        private readonly HttpClient _httpClient;
        public AssignmentService(HttpClient http)
        {
            _httpClient = http;
        }
        
        public async Task<ServiceResponse<List<AssignmentDTO>>> GetAssignmentsByWorkId(int workId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<AssignmentDTO>>>("/api/assignment/workid");
            if (result != null && result.Data != null)
            {
                return result;
            }

            return null;
        }

        public async Task<ServiceResponse<List<AssignmentDTO>>> GetAssignmentsByUserId(int userId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<AssignmentDTO>>>($"/api/assignment/get/{userId}");
            if (result != null && result.Data != null)
            {
                return result;
            }

            return null;
        }

        public async Task<ServiceResponse<AssignmentDTO>> GetAssignment(int assignmentId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<AssignmentDTO>>($"api/assignment/{assignmentId}");
            return result;
        }

        public async Task<ServiceResponse<int>> Update(int assignmentId, int userId)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/assignment/update/{assignmentId}/{userId}", "");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}

		public async Task<ServiceResponse<int>> Complete(int assignmentId, int workedHours, string comments)
		{
            var result = await _httpClient.PutAsJsonAsync($"api/assignment/complete/{assignmentId}/{workedHours}/{comments}", "");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
	}
}
