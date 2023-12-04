using Agrogar.Client.Pages;
using Agrogar.Shared;
using Agrogar.Shared.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Agrogar.Server.Services.WorkBuilderService
{
    public class WorkAssemblyService : IWorkAssemblyService
    {

        private readonly ITaskTypeService _taskTypeService;
        private readonly IJobTitleService _jobTitleService;
        private readonly IWorkService _workService;
        private readonly IAssignmentService _assignmentService;
        private List<TaskType>? _taskTypes;
        private List<JobTitle>? _jobTitles;
        private List<Work>? _rawWorks;
        private List<Assignment>? _rawAssignments;

        public WorkAssemblyService(ITaskTypeService taskTypeService, IJobTitleService jobPositionService, IWorkService workService, IAssignmentService assignmentService)
        {
            _jobTitleService = jobPositionService;
            _taskTypeService = taskTypeService;
            _workService = workService;
            _assignmentService = assignmentService;
        }

        public async Task<ServiceResponse<List<WorkDTO>>> GetAllWorks(int propertyId)
        {
            await SetWorkListByPropertyId(propertyId);
            
			var response = new ServiceResponse<List<WorkDTO>>();
            var result = BuildWorks(_rawWorks);
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

        public async Task<ServiceResponse<WorkDTO>> GetWork(int workId)
        {
            await SetJobsAndTaskTypes();
            await SetRawAssignmentsAsync(workId);
            var response = new ServiceResponse<WorkDTO>();
            var workResult = await _workService.GetWork(workId);
            var work = workResult.Data;
            var workDTO = BuildWork(work);
            if (workDTO == null)
            {
                response.Success = false;
            }
            else
            {
                response.Data = workDTO;
            }
            return response;
        }

        private WorkDTO BuildWork(Work work)
        {
            var taskTypes = _taskTypes.FirstOrDefault(t => t.Id == work.TaskTypeId);
            var assignments = _rawAssignments.Where(a => a.WorkId == work.Id).ToList();
            List<AssignmentDTO> assignmentsDTO = new List<AssignmentDTO>();
            foreach(var assignment in assignments)
            {

                var assignmentDTO = new AssignmentDTO
                {
                    Id = assignment.Id,
                    JobTitle = assignment.JobTitle,
                    LicensePP = assignment.LicensePP,
                    IsCompleted = assignment.IsCompleted,
                    Comments = assignment.Comments,
                    WorkedHours = assignment.WorkedHours,
                    DateCompleted = assignment.DateCompleted,
                    IsAvailable = assignment.IsAvailable
                };
                assignmentsDTO.Add(assignmentDTO);
            }

            return new WorkDTO
            {
                Id = work.Id,
                PropertyId = work.PropertyId,
                StartDate = work.StartDate,
                EndDate = work.EndDate,
                TaskType = taskTypes,
                Details = work.Details,
                IsActive = work.IsActive,
                Assignments = assignmentsDTO
            };

        }

        private List<WorkDTO> BuildWorks(List<Work> works)
        {
            List<WorkDTO> worksDTO = new List<WorkDTO>();
			foreach(var work in works)
            {
				SetRawAssignmentsAsync(work.Id).Wait();
				var workDTO = BuildWork(work);
				worksDTO.Add(workDTO);
			}
            return worksDTO;
        }

        private async Task<List<TaskType>> GetTaskTypeListAsync()
        {
            var taskTypesResponse = await _taskTypeService.GetTaskTypes();
            var taskTypes = taskTypesResponse.Data;
            return taskTypes;
        }

        private async Task<List<JobTitle>> GetJobTitleListAsync()
        {
            var jobTitlesResponse = await _jobTitleService.GetJobTitles();
            var jobTitles = jobTitlesResponse.Data;
            return jobTitles;
        }

        private async Task<List<Work>> GetRawWorksAsync(int propertyId)
        {
            var worksResponse = await _workService.GetWorks(propertyId);
            var works = worksResponse.Data;
            return works;
        }

        private async Task SetRawAssignmentsAsync(int workId)
        {
            var assignmentsResponse = await _assignmentService.GetAssignmentsByWorkId(workId);
            _rawAssignments = assignmentsResponse.Data;
        }


        private async Task SetWorkListByPropertyId(int propertyId)
        {
            await SetJobsAndTaskTypes();
            var rawWorks = await GetRawWorksAsync(propertyId);
            _rawWorks = rawWorks;
        }


        private async Task SetJobsAndTaskTypes()
        {
            var taskTypes = await GetTaskTypeListAsync();
            _taskTypes = taskTypes;

            var jobTitles = await GetJobTitleListAsync();
            _jobTitles = jobTitles;
        }

    }
}
