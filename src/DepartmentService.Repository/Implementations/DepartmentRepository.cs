using Dapper;
using DepartmentService.Data;
using DepartmentService.InternalModels.Entities;
using System.Data;

namespace DepartmentService.Repository;

public class DepartmentRepository : BaseRepository, IDepartmentRepository
{
    public DepartmentRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IReadOnlyCollection<DepartmentEntity>> GetAllAsync()
    {
        var rows = await QueryAsync<DepartmentEntity>(
            StoredProcedureNames.GetDepartments,
            commandType: CommandType.StoredProcedure);
        return rows.ToList();
    }
}


