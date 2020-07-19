using System.Collections.Generic;
using System.Threading.Tasks;
using Narvan.Domains.Roles.Entities;

namespace Narvan.Domains.Roles.Repositories
{
    public interface IRoleRepositoryQuery
    {
        Task<List<Role>> GetAllRole();
        Task<Role> GetRoleById(long roleId);
    }
}