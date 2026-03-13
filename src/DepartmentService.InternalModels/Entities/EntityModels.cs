namespace DepartmentService.InternalModels.Entities;

public class DepartmentEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string HeadOfDepartment { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public List<string> Services { get; set; } = new();
    public bool IsActive { get; set; }
}


