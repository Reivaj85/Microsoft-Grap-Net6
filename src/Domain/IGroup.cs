namespace POC_MGrap.Domain;

using Microsoft.Graph;
public interface IGroup  {
    Task<IGraphServiceGroupsCollectionPage?> GetAllowedGroups();
    Task<IGraphServiceGroupsCollectionPage?> GetByName(string name);
}
