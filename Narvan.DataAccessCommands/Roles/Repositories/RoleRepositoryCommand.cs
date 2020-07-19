using Narvan.DataAccessCommands.Context;
using Narvan.Domains.Roles.Entities;
using Narvan.Domains.Roles.Repositories;
using System.Threading.Tasks;

namespace Narvan.DataAccessCommands.Roles.Repositories
{
    public class RoleRepositoryCommand : IRoleRepositoryCommand
    {
        private readonly NarvanContext _context;

        public RoleRepositoryCommand(NarvanContext context)
        {
            _context = context;
        }

        public async Task AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public void UpdateRole(Role role)
        {
           
            _context.Roles.Update(role);
        }

        public void RemoveRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public async Task RemoveRoleById(long roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            RemoveRole(role);
            
        }
    }
}