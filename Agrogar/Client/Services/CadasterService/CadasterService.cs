using Agrogar.Shared;
using System.Net;

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
			try
			{
				var result = await _httpClient.GetFromJsonAsync<CadasterData>($"api/cadaster/{provincia}/{municipio}/{referenciaCatastral}");
				return result;
			}
			catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
			{
				CadasterData cadasterData = new CadasterData
				{
					Success = false,
					AxisX = "",
					AxisY = "",
					Address = ""
				};
				return cadasterData;
			}
		}
    }
}
