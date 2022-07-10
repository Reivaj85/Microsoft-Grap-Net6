using Microsoft.AspNetCore.Mvc;
using POC_MGrap.Domain.DTO;
using POC_MGrap.Services.Interfaces;

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
        IEnumerable<GroupDto> groups = string.IsNullOrEmpty(name)
            ? await _group.GetAllowedGroups() 
            : await _group.GetByName(name);
        return Ok( groups );
    }
}
