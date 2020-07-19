using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narvan.Domains.Roles.Entities;
using Narvan.Domains.Roles.Repositories;

namespace Narvan.DataAccessQueries.Roles.Repositories
{
    public class RoleRepositoryQuery: IRoleRepositoryQuery
    {
        private SqlConnection _db;

        public RoleRepositoryQuery(IConfiguration configuration)
        {
            _db=new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }
        public async Task<List<Role>> GetAllRole()
        {
            return (await _db.QueryAsync<Role>("select * from roles")).ToList();
        }

        public async Task<Role> GetRoleById(long roleId)
        {
            return await _db.QueryFirstOrDefaultAsync<Role>("select * from roles where id=@roleId",
                new {@roleId = roleId});
        }
    }
}