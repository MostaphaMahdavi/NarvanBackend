using System.Collections.Generic;
using System.Threading.Tasks;
using Narvan.Domains.Users.Entities;

namespace Narvan.Domains.Users.Repositories
{
    public interface IUserRepositoryCommand
    {
   
        Task AddUser(User user);
        void UpdateUser(User user);
        void RemoveUser(User user);
        Task RemoveUserById(long userId);

        Task RegisterUser(User user);

    }
}