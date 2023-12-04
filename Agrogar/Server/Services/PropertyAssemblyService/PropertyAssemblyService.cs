using Agrogar.Shared;
using Agrogar.Shared.DTOs;
using Azure;

namespace Agrogar.Server.Services.PropertyBuilderService
{
    public class PropertyAssemblyService : IPropertyAssemblyService
    {
        private readonly IPropertyService _propertyService;
        private readonly IWorkPhaseService _workPhaseService;
        private readonly ICategoryService _categoryService;
        private List<Category>? _categories;
        private List<WorkPhase>? _workPhases;
        private List<Property>? _rawProperties;

        public PropertyAssemblyService(IPropertyService propertyService, IWorkPhaseService workPhaseService, ICategoryService categoryService)
        {
            _propertyService = propertyService;
            _workPhaseService = workPhaseService;
            _categoryService = categoryService;
        }

        public async Task<ServiceResponse<List<PropertyDTO>>> GetPropertiesByUserId(int userId)
        {
            await SetListsIfNull();
            var response = new ServiceResponse<List<PropertyDTO>>();
            var properties = _rawProperties.Where(p => p.UserId == userId);
            var result = await BuildProperties(properties.ToList());
            if (result == null)
            {
                response.Success = false;
            }
            else
            {
                response.Data = result;
            }

            return response;
        }

        public async Task<ServiceResponse<List<PropertyDTO>>> GetAllProperties()
        {
            await SetListsIfNull();
            var response = new ServiceResponse<List<PropertyDTO>>();
            var result = await BuildProperties(_rawProperties);
            if (result == null)
            {
                response.Success = false;
            }
            else
            {
                response.Data = result;
            }
            return response;
        }

        public async Task<ServiceResponse<PropertyDTO>> GetProperty(int propertyId)
        {
            await SetListsIfNull();
            var response = new ServiceResponse<PropertyDTO>();
            var propertyResult = await _propertyService.GetProperty(propertyId);
            var property = propertyResult.Data;
            var propertyDTO = BuildProperty(property);
            if (propertyDTO == null)
            {
                response.Success = false;
            }
            else
            {
                response.Data = await propertyDTO;
            }
            return response;
        }

        private async Task<PropertyDTO> BuildProperty(Property property)
        {
            var category = _categories.FirstOrDefault(c => c.Id == property.CategoryId);
            var workPhase = _workPhases.FirstOrDefault(w => w.Id == property.WorkPhaseId);
            
            return new PropertyDTO
            {
                Id = property.Id,
                CadasterReference = property.CadasterReference,
                Province = property.Province,
                Municipality = property.Municipality,
                UserId = property.UserId,
                Crop = property.Crop,
                WorkPhase = workPhase,
                Category = category,
                Size = property.Size
            };

        }

        private async Task<List<PropertyDTO>> BuildProperties(List<Property> properties)
        {
            List<PropertyDTO> propertyDTOs = new List<PropertyDTO>();
            foreach(var property in properties)
            {
                var assembledProperty = await BuildProperty(property);
                propertyDTOs.Add(assembledProperty);
            }
            return propertyDTOs;
        }

        private async Task<List<Category>> GetCategoryListAsync()
        {
            var categoriesResult = await _categoryService.GetCategories();
            return categoriesResult.Data;
        }

        private async Task<List<WorkPhase>> GetWorkPhaseListAsync()
        {
            var workPhasesResult = await _workPhaseService.GetWorkPhases();
            return workPhasesResult.Data;
        }

        private async Task<List<Property>> GetRawPropertiesAsync()
        {
            var propertiesResult = await _propertyService.GetProperties();
            return propertiesResult.Data;
        }

        private async Task SetListsIfNull()
        {
            if (_categories == null)
            {
                var taskTypes = await GetCategoryListAsync();
                _categories = taskTypes;
            }
            if (_workPhases == null)
            {
                var jobTitles = await GetWorkPhaseListAsync();
                _workPhases = jobTitles;
            }
            if (_rawProperties == null)
            {
                var rawWorks = await GetRawPropertiesAsync();
                _rawProperties = rawWorks;
            }
        }
       
    }
}
