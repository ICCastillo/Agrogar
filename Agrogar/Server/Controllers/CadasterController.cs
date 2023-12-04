using Agrogar.Shared;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Agrogar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadasterController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://ovc.catastro.meh.es/ovcservweb/ovcswlocalizacionrc/ovccoordenadas.asmx/Consulta_CPMRC";

        public CadasterController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet("{provincia}/{municipio}/{referenciaCatastral}")]
        public async Task<ActionResult<CadasterData>> GetCadasterData(string provincia, string municipio, string referenciaCatastral)
        {

            var parameters = $"Provincia={provincia}&Municipio={municipio}&SRS=EPSG:4326&RC={referenciaCatastral.Substring(0, Math.Min(referenciaCatastral.Length, 14))}";
            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl)
            {
                Content = new StringContent(parameters, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded")
            };
            
            var result = await _httpClient.SendAsync(request);
            var readedResult = await result.Content.ReadAsStringAsync();

            XDocument xmlDoc = XDocument.Parse(readedResult);

            XNamespace ns = "http://www.catastro.meh.es/";

            var coordenadas = xmlDoc.Root?.Element(ns + "coordenadas")?.Element(ns + "coord");
            var geo = coordenadas?.Element(ns + "geo");
            var ldt = coordenadas?.Element(ns + "ldt");
            CadasterData cadasterData = new CadasterData();
            if (geo != null && ldt != null)
            {
                cadasterData = new CadasterData
                {
                    AxisX = geo.Element(ns + "xcen")?.Value,
                    AxisY = geo.Element(ns + "ycen")?.Value,
                    Address = ldt.Value
                };

                return Ok(cadasterData);
            }
            else
            {
                return BadRequest(cadasterData);
            }
            
        }
    }
}
