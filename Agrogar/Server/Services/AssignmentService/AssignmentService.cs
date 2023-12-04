using Agrogar.Shared;

namespace Agrogar.Server.Services.AssignmentService
{
	public class AssignmentService : IAssignmentService
	{
		private readonly DataContext _context;

		public AssignmentService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<Assignment>>> GetAssignmentsByWorkId(int workId)
		{
			var response = new ServiceResponse<List<Assignment>>
			{
				Data = await _context.Assignment.Where(a => a.WorkId.Equals(workId)).ToListAsync()
			};
			return response;
		}

        public async Task<ServiceResponse<List<Assignment>>> GetAssignmentsByUserId(int userId)
        {
            var response = new ServiceResponse<List<Assignment>>
            {
                Data = await _context.Assignment.Where(a => a.UserId == userId).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Assignment>> GetAssignment(int assignmentId)
		{
			var response = new ServiceResponse<Assignment>();
			var assignment = await _context.Assignment.FindAsync(assignmentId);
			if (assignment == null)
			{
				response.Success = false;
				response.Message = "No existe esta asignación.";
			}
			else
			{
				response.Data = assignment;
			}

			return response;
		}
		private async Task<bool> AssignmentExists(int workId)
		{
			bool workBool = await _context.Assignment.AnyAsync(a => a.WorkId.Equals(workId));
			if (workBool)
			{
				return true;
			}
			return false;
		}

		public async Task<ServiceResponse<int>> Register(Assignment assignment)
		{
			if (await AssignmentExists(assignment.WorkId))
			{
				return new ServiceResponse<int> { Success = false, Message = "El trabajo ya esta asignado" };
			}

			_context.Assignment.Add(assignment);
			await _context.SaveChangesAsync();
			return new ServiceResponse<int> { Data = assignment.Id, Success = true };
		}

		public async Task<ServiceResponse<int>> Update(int assignmentId, int userId)
		{
			var assignment = await _context.Assignment.FindAsync(assignmentId);
			if (await AssignmentExists(assignment.WorkId))
			{
				assignment.UserId = userId;
				assignment.IsAvailable = false;
				await _context.SaveChangesAsync();
				return new ServiceResponse<int> { Data = assignment.Id, Success = true, Message = "Se asignó correctamente el trabajo." };
			}
			return new ServiceResponse<int> { Success = false};
		}

		public async Task<ServiceResponse<int>> Complete(int assignmentId, int workedHours, string comments)
		{
			var assignment = await _context.Assignment.FindAsync(assignmentId);
			if (await AssignmentExists(assignment.WorkId))
			{
				assignment.DateCompleted = DateTime.Now;
				assignment.WorkedHours = workedHours;
				assignment.Comments = comments;
				assignment.IsCompleted = true;
				await _context.SaveChangesAsync();
				return new ServiceResponse<int> { Data = assignment.Id, Success = true, Message = "Se completo correctamente el trabajo." };
			}
			return new ServiceResponse<int> { Success = false, Message = "No se pudo completar el trabajo." };
		}
	}
}
