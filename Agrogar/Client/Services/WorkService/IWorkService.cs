namespace Agrogar.Client.Services.WorkService
{
    public interface IWorkService
    {
        List<Work> Works { get; set; }
        Task<ServiceResponse<List<WorkDTO>>> GetWorks(int propertyId);
        Task<ServiceResponse<WorkDTO>> GetWork(int workId);
        Task<ServiceResponse<int>> Register(WorkAssignmentRegisterDTO request);
    }
}
