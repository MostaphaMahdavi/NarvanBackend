using Narvan.DataAccessCommands.Context;
using Narvan.Domains.Commons;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Repositories;
using System.Threading.Tasks;

namespace Narvan.DataAccessCommands.Users.Repositories
{
    public class UserRepositoryCommand : IUserRepositoryCommand
    {
        private readonly NarvanContext _context;


        public UserRepositoryCommand(NarvanContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            user.EmailActiveCode = Generator.GenerateGuid();
            await _context.Users.AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void RemoveUser(User user)
        {
            user.IsDelete = true;
            UpdateUser(user);
        }

        public async Task RemoveUserById(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            RemoveUser(user);
        }

        public async Task RegisterUser(User user)
        {
           
            await _context.Users.AddAsync(user);
        }
    }
}