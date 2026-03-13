using DepartmentService.InternalModels.Entities;

namespace DepartmentService.InternalModels.DTOs;

public class CreateDepartmentDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string HeadOfDepartment { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public List<string> Services { get; set; } = new();
}

public class UpdateDepartmentDto : CreateDepartmentDto
{
    public bool IsActive { get; set; } = true;
}

public class DepartmentDto : UpdateDepartmentDto
{
    public int Id { get; set; }

    public static DepartmentDto FromEntity(DepartmentEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        HeadOfDepartment = entity.HeadOfDepartment,
        Email = entity.Email,
        Phone = entity.Phone,
        Location = entity.Location,
        Services = entity.Services.ToList(),
        IsActive = entity.IsActive
    };
}


