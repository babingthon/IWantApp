using Dapper;
using IWantApp.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infra.Data;

public class QueryAllUsersWithClaimNames
{
    private readonly IConfiguration configuration;

    public QueryAllUsersWithClaimNames(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionStrings:IWantDb"]);
        var query =
            @"select Email, ClaimValue as Name 
            from AspNetUsers u
            inner join AspNetUserClaims c on u.Id = c.UserId 
            and ClaimType = 'Name'
            ORDER BY name
            OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";
        return db.Query<EmployeeResponse>(
            query,
            new { page, rows }
            );
    }
}
