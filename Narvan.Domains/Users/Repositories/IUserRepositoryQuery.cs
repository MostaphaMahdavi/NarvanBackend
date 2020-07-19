using System.Collections.Generic;
using System.Threading.Tasks;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Queries;

namespace Narvan.Domains.Users.Repositories
{
    public interface IUserRepositoryQuery
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(long userId);
        Task<bool> IsEmailExists(string email);
        Task<User> LoginUser(LoginUserInfoQuery loginInfo);
        Task<User> GetUserByActiveCode(string activeCode);

    }
}