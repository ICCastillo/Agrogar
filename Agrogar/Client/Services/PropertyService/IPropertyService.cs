namespace Agrogar.Client.Services.PropertyService
{
    public interface IPropertyService
    {
        List<Property> Properties { get; set; }
        Task<ServiceResponse<List<PropertyDTO>>> GetProperties();
        Task<ServiceResponse<PropertyDTO>> GetProperty(int propertyId);
        Task<ServiceResponse<int>> Register(PropertyRegisterDTO request);
        Task<ServiceResponse<List<PropertyDTO>>> GetPropertiesByUserId(int userId);
        Task<ServiceResponse<int>> UpdateProperty(int propertyId, int workPhaseId);
    }
}
