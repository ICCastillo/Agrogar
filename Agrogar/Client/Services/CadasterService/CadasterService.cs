namespace Agrogar.Client.Services.CadasterService
{
    public class CadasterService : ICadasterService
    {
        private readonly HttpClient _httpClient;
        public CadasterService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<CadasterData> GetCadasterData(string provincia, string municipio, string referenciaCatastral)
        {
            var result = await _httpClient.GetFromJsonAsync<CadasterData>($"api/cadaster/{provincia}/{municipio}/{referenciaCatastral}");
            return result;
        }
    }
}
