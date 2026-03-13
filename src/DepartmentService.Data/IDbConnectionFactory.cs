using System.Data;

namespace DepartmentService.Data;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}

