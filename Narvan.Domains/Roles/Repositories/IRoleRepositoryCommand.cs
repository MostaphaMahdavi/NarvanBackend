using System.Threading.Tasks;
using Narvan.Domains.Roles.Entities;
using Narvan.Domains.Users.Entities;

namespace Narvan.Domains.Roles.Repositories
{
    public interface IRoleRepositoryCommand
    {
        Task AddRole(Role role);
        void UpdateRole(Role role);
        void RemoveRole(Role role);
        Task RemoveRoleById(long roleId);
    }
}