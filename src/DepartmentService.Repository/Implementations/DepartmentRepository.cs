using Dapper;
using DepartmentService.Data;
using DepartmentService.InternalModels.Entities;

namespace DepartmentService.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DepartmentRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IReadOnlyCollection<DepartmentEntity>> GetAllAsync()
    {
        try
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Departments";
            var rows = await connection.QueryAsync<DepartmentEntity>(sql);
            return rows.ToList();
        }
        catch
        {
            return new List<DepartmentEntity>();
        }
    }
}


