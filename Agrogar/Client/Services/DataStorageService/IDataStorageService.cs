namespace Agrogar.Client.Services.DataStorageService
{
    public interface IDataStorageService
    {
        List<JobTitle> JobTitles { get; set; }
        List<Category> Categories { get; set; }
        Dictionary<WorkPhase, List<TaskType>> WorkPhasesAndTasks { get; set; }
		List<PropertyDTO> DetailViewProperties { get; set; }
        List<PropertyDTO> ListViewProperties { get; set; }
        int PropertyId { get; set; }
		IEnumerable<WorkDTO>? AssignmentApplyWorkDTOs { get; set; }
        WorkDTO WorkDTO { get; set; }
        List<AssignmentDTO> MyWorksAssignments { get; set; }
        AssignmentDTO AssignmentDTO { get; set; }
        int UserId { get; set; }
        event Action OnChange;
        void NotifyStateChanged();
        void SetWorkPhaseToProperty(int propertyId, WorkPhase workPhase);
        void SetNewWorkToProperty(int propertyId, WorkDTO work);
        void SetNewProperty(PropertyDTO property);
        void SetFilteredList(List<PropertyDTO> filteredList);
        void SetAssignmentToMyWorks(List<AssignmentDTO> assignments);
        void StateHasChanged();


    }
}
