using AutoMapper;
using Microsoft.Graph;
using POC_MGrap.Domain.DTO;
using POC_MGrap.Infrastructure;
using POC_MGrap.Services.Interfaces;

namespace POC_MGrap.Services;
internal class GroupService : MGrapProxy, IGroup {
    private readonly IMapper _mapper;

    public GroupService(IConfiguration configuration, IMapper mapper ) : base(configuration) {
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GroupDto>> GetAllowedGroups() {
        var queryOptions = new List<QueryOption>()
        {
            new("$count", "true")
        };

        IEnumerable<Group>? groups = await GraphServiceClient?.Groups.Request(queryOptions)
            .Filter("startswith(displayName, 'PHZone')")
            .Select(g => new {
                g.Id,
                g.DisplayName,
                g.Description,
                g.Mail
            })
            .GetAsync()!;
        return _mapper.Map<IEnumerable<Group>,IEnumerable<GroupDto>>(groups);
    }

    public async Task<IEnumerable<GroupDto>> GetByName(string name) {
        IEnumerable<Group>? group = await GraphServiceClient?.Groups.Request().Filter($"displayName eq '{ name }'").GetAsync()!;
        return _mapper.Map<IEnumerable<Group>,IEnumerable<GroupDto>>(group);
    }
}
