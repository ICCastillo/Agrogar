using Agrogar.Shared.DTOs;

namespace Agrogar.Server.Services.PropertyBuilderService
{
    public interface IPropertyAssemblyService
    {
        Task<ServiceResponse<PropertyDTO>> GetProperty(int propertyId);
        Task<ServiceResponse<List<PropertyDTO>>> GetAllProperties();
        Task<ServiceResponse<List<PropertyDTO>>> GetPropertiesByUserId(int userId);
    }
}
