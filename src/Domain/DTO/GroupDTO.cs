namespace POC_MGrap.Domain.DTO; 

public class GroupDto {
    public string Id { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Mail { get; set; }
}
