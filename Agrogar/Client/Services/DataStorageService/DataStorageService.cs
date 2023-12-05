namespace Agrogar.Client.Services.DataStorageService
{
    public class DataStorageService : IDataStorageService
    {
        public List<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public Dictionary<WorkPhase, List<TaskType>> WorkPhasesAndTasks { get; set; }
		public PropertyDTO PropertyDTO { get; set; } = new PropertyDTO();
        public IEnumerable<WorkDTO>? AssignmentApplyWorkDTOs { get; set; } = new List<WorkDTO>();
		public List<PropertyDTO> DetailViewProperties { get; set; } = new List<PropertyDTO>();
		public List<PropertyDTO> ListViewProperties { get; set; } = new List<PropertyDTO>();
        public WorkDTO WorkDTO { get; set; } = new WorkDTO();
        public List<AssignmentDTO> MyWorksAssignments { get; set; } = new List<AssignmentDTO>();
        public AssignmentDTO AssignmentDTO { get; set; } = new AssignmentDTO();
        public int UserId { get; set; }
		public int PropertyId { get; set; }
		public event Action OnChange;

        public void NotifyStateChanged() => OnChange?.Invoke();

        public void SetWorkPhaseToProperty(int propertyId, WorkPhase workPhase)
        {
            foreach(var property in DetailViewProperties)
            {
                if(property.Id == propertyId)
                {
					property.WorkPhase = workPhase;
                }
            }

            NotifyStateChanged();
        }

        public void SetNewWorkToProperty(int propertyId, WorkDTO work)
        {
            foreach(var property in DetailViewProperties)
            {
                if (property.Id == propertyId)
                {
                    property.Works.Add(work);
                }
            }

			NotifyStateChanged();
		}

        public void SetNewProperty(PropertyDTO property)
        {
            DetailViewProperties.Add(property);
            NotifyStateChanged();
        }

        public void SetFilteredList(List<PropertyDTO> properties)
        {
            ListViewProperties = properties;
            NotifyStateChanged();
        }

        public void SetAssignmentToMyWorks(List<AssignmentDTO> assignments)
        {
            MyWorksAssignments = assignments.ToList();
            NotifyStateChanged();
        }

        public void SetAssignmentApplyWorkDTOs(IEnumerable<WorkDTO> works)
        {
			AssignmentApplyWorkDTOs = works.ToList();
			NotifyStateChanged();
		}

    }
}