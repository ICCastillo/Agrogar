namespace Agrogar.Server.Services.PropertyService
{
	public interface IPropertyService
	{
		Task<ServiceResponse<List<Property>>> GetProperties();
		Task<ServiceResponse<Property>> GetProperty(int productId);
		Task<ServiceResponse<int>> Register(Property property);
		Task<bool> PropertyExists(string coordenates);
		Task<ServiceResponse<int>> DeleteProperty(int id);
		Task<ServiceResponse<List<Property>>> GetPropertiesByUserId(int userId);
		Task<ServiceResponse<int>> UpdateProperty(int propertyId,int workPhaseId);

    }
}
