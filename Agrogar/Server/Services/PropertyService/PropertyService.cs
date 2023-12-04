using Agrogar.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Agrogar.Server.Services.PropertyService
{
	public class PropertyService : IPropertyService
	{
		private readonly DataContext _context;

		public PropertyService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<Property>>> GetProperties()
		{
			var response = new ServiceResponse<List<Property>>
			{
				Data = await _context.Properties.ToListAsync()
			};
			return response;
		}

		public async Task<ServiceResponse<Property>> GetProperty(int propertyId)
		{
			var response = new ServiceResponse<Property>();
			var property = await _context.Properties.FindAsync(propertyId);
			if(property == null)
			{
				response.Success = false;
				response.Message = "No existe esta propiedad.";
			}
			else
			{
				response.Data = property;
			}

			return response;
		}

        public async Task<ServiceResponse<List<Property>>> GetPropertiesByUserId(int userId)
        {
            var response = new ServiceResponse<List<Property>>();
            var properties = await _context.Properties.Where(p => p.UserId == userId).ToListAsync();
            if (properties == null)
            {
                response.Success = false;
                response.Message = "Ese usuario no tiene propiedades";
            }
            else
            {
                response.Data = properties;
            }

            return response;
        }

        public async Task<bool> PropertyExists(string cadasterReference)
		{
			if (await _context.Properties.AnyAsync(property => property.CadasterReference.Equals(cadasterReference)))
			{
				return true;
			}
			return false;
		}


		public async Task<ServiceResponse<int>> Register(Property property)
		{
			if(await PropertyExists(property.CadasterReference))
			{
				return new ServiceResponse<int> { Success = false, Message = "La propiedad ya esta registrada."  };
			}
			
			_context.Properties.Add(property);
			await _context.SaveChangesAsync();
			return new ServiceResponse<int> { Data = property.Id, Success = true, Message = "La propiedad se registro correctamente."};
		}

		public async Task<ServiceResponse<int>> DeleteProperty(int id)
		{
			var property = await GetProperty(id);

			if (!property.Success)
			{
				return new ServiceResponse<int> { Success = false, Message = "Hubo un error al intentar eliminar la propiedad" };
			}
			_context.Properties.Remove(property.Data);
			await _context.SaveChangesAsync();
			return new ServiceResponse<int> { Success = true, Message = "La propiedad se elimino correctamente." };

		}

		public async Task<ServiceResponse<int>> UpdateProperty(int propertyId, int workPhaseId)
		{
			var property = await GetProperty(propertyId);
			if (!property.Success)
			{
				return new ServiceResponse<int> { Success = false, Message = "Hubo un error al intentar actualizar la propiedad" };
			}
			property.Data.WorkPhaseId = workPhaseId;
			_context.Properties.Update(property.Data);
			await _context.SaveChangesAsync();
			return new ServiceResponse<int> { Success = true, Message = "La propiedad se actualizo correctamente." };
		}
	}
}
