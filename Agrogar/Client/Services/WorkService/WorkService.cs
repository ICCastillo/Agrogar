using Agrogar.Shared;

namespace Agrogar.Client.Services.WorkService
{
    public class WorkService : IWorkService
    {
        private readonly HttpClient _httpClient;
        public WorkService(HttpClient http)
        {
            _httpClient = http;
        }
        public List<Work> Works { get; set; } = new List<Work>();


        public async Task<ServiceResponse<List<WorkDTO>>> GetWorks(int propertyId)
        {

            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<WorkDTO>>>($"/api/work/all/{propertyId}");
            if (result != null && result.Data != null)
            {
                return result;
            }

            return null;
        }

        public async Task<ServiceResponse<WorkDTO>> GetWork(int workId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<WorkDTO>>($"api/work/{workId}");
            return result;
        }

        public async Task<ServiceResponse<int>> Register(WorkAssignmentRegisterDTO workAssignmentRegisterDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/work/register", workAssignmentRegisterDTO);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
            return response;
        }
    }
}
