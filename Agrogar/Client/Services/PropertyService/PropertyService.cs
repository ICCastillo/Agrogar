

using System.Net.Http.Json;

namespace Agrogar.Client.Services.PropertyService
{
    public class PropertyService : IPropertyService
    {
        private readonly HttpClient _httpClient;
        public PropertyService(HttpClient http)
        {
            _httpClient = http;
        }
        public List<Property> Properties { get; set; } = new List<Property>();


        public async Task<ServiceResponse<List<PropertyDTO>>> GetProperties()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<PropertyDTO>>>("/api/property");
            if (result != null && result.Data != null)
            {
                return result;
            }

            return null;
        }

        public async Task<ServiceResponse<List<PropertyDTO>>> GetPropertiesByUserId(int userId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<PropertyDTO>>>($"api/property/get/{userId}");
            return result;
        }

        public async Task<ServiceResponse<PropertyDTO>> GetProperty(int propertyId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<PropertyDTO>>($"api/property/{propertyId}");
            return result;
        }

        public async Task<ServiceResponse<int>> Register(PropertyRegisterDTO request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/property/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

		public async Task<ServiceResponse<int>> UpdateProperty(int propertyId, int workPhaseId)
		{
			var result = await _httpClient.PutAsJsonAsync($"api/property/update/{propertyId}/{workPhaseId}","");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}
	}
}
