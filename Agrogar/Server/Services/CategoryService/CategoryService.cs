using Agrogar.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Agrogar.Server.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly DataContext _context;
		public CategoryService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<Category>>> GetCategories()
		{
			var categories = await _context.Category.ToListAsync();
			return new ServiceResponse<List<Category>> 
			{
				Data = categories 
			};
		}
	}
}
