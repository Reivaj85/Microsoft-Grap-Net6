using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using POC_MGrap.Domain;

namespace POC_MGrap.Controllers; 

[ApiController]
[Route("[controller]")]
public class GroupsController : ControllerBase {
    private readonly IGroup _group;

    public GroupsController(IGroup group) {
        _group = group;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? name) {
        IGraphServiceGroupsCollectionPage? groups = string.IsNullOrEmpty(name)
            ? await _group.GetAllowedGroups() 
            : await _group.GetByName(name);
        return Ok( groups );
    }
}
