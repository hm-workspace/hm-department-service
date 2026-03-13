using DepartmentService.InternalModels.Entities;

namespace DepartmentService.Services;

public static class DepartmentStore
{
    public static int DepartmentSeed = 1;
    public static readonly List<DepartmentEntity> Departments = new()
    {
        new DepartmentEntity
        {
            Id = 1,
            Name = "Cardiology",
            Description = "Heart care and diagnostics",
            HeadOfDepartment = "Dr. Kiran Rao",
            Email = "cardiology@hm.local",
            Phone = "04010001001",
            Location = "Block A, Floor 2",
            Services = new List<string> { "ECG", "Echo", "Consultation" },
            IsActive = true
        }
    };
}


