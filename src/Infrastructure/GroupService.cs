using Microsoft.Graph;
using POC_MGrap.Domain;

namespace POC_MGrap.Infrastructure;
internal class GroupService : MGrapProxy, IGroup {
    public GroupService(IConfiguration configuration) : base(configuration) {
    }
    
    public async Task<IGraphServiceGroupsCollectionPage?> GetAllowedGroups() {
        var queryOptions = new List<QueryOption>()
        {
            new("$count", "true")
        };
        
        return await GraphServiceClient?.Groups
            .Request( queryOptions )
            .Filter("startswith(displayName, 'PHZone')")
            .Select("id,displayName")
            .GetAsync()!;
    }

    public async Task<IGraphServiceGroupsCollectionPage?> GetByName(string name) {
        return await GraphServiceClient?.Groups.Request().Filter($"displayName eq '{ name }'").GetAsync()!;
    }
}
