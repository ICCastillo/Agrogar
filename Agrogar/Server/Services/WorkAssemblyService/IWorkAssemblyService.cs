using Agrogar.Shared.DTOs;

namespace Agrogar.Server.Services.WorkBuilderService
{
    public interface IWorkAssemblyService
    {
        Task<ServiceResponse<WorkDTO>> GetWork(int workId);
        Task<ServiceResponse<List<WorkDTO>>> GetAllWorks(int propertyId);
    }
}
