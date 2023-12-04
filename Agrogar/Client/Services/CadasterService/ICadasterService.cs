namespace Agrogar.Client.Services.CadasterService
{
    public interface ICadasterService
    {
        Task<CadasterData> GetCadasterData(string provincia, string municipio, string referenciaCatastral);
    }
}
