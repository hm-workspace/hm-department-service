using DepartmentService.InternalModels.Entities;

namespace DepartmentService.Repository;

public interface IDepartmentRepository
{
    Task<IReadOnlyCollection<DepartmentEntity>> GetAllAsync();
}

