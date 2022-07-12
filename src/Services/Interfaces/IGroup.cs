using POC_MGrap.Domain.DTO;

namespace POC_MGrap.Services.Interfaces;
public interface IGroup  {
    Task<IEnumerable<GroupDto>> GetAllowedGroups();
    Task<IEnumerable<GroupDto>> GetByName(string name);
    Task<IEnumerable<GroupDto>> GetStartWithByName(string likeName);
}
