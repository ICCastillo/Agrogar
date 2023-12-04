using Agrogar.Server.Data;
using Agrogar.Shared;
using Microsoft.EntityFrameworkCore;

namespace Agrogar.Server.Services.WorkService
{
	public class WorkService : IWorkService
	{
		private readonly DataContext _context;

		public WorkService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<Work>>> GetWorks(int propertyId)
		{
			var response = new ServiceResponse<List<Work>>
			{
				 Data = await _context.Works.Where(w => w.PropertyId.Equals(propertyId)).ToListAsync()
			};

			return response;
		}

		public async Task<ServiceResponse<Work>> GetWork(int workId)
		{
			var response = new ServiceResponse<Work>();
			var work = await _context.Works.FindAsync(workId);
			if (work == null)
			{
				response.Success = false;
				response.Message = "No existe este trabajo.";
			}
			else
			{
				response.Data = work;
			}

			return response;
		}

		public async Task<ServiceResponse<int>> Register(Work work, List<Assignment> assignments)
		{
			if (await WorkExists(work))
			{
				return new ServiceResponse<int> { Success = false, Message = "El trabajo ya esta registrado." };
			}

			_context.Works.Add(work);
			await _context.SaveChangesAsync();
			foreach (var assignment in assignments)
			{
				assignment.WorkId = work.Id;
				_context.Assignment.Add(assignment);
			}
			await _context.SaveChangesAsync();
			return new ServiceResponse<int> { Data = work.Id, Success = true, Message = "El trabajo se registro correctamente." };
		}

		public async Task<bool> WorkExists(Work work)
		{
			bool exists = await _context.Works.AnyAsync(w => w.PropertyId == work.PropertyId && w.TaskTypeId == work.TaskTypeId);
			if(exists)
			{
				return true;
			}
			return false;
		}
	}
}
