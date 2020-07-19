using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Narvan.Domains.Users.Queries;

namespace Narvan.DataAccessQueries.Users.Repositories
{
    public class UserRepositoryQuery : IUserRepositoryQuery
    {
        private readonly SqlConnection _db;

        public UserRepositoryQuery(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }
        public async Task<List<User>> GetAllUser()
        {
            return (await _db.QueryAsync<User>("select * from users")).ToList();
            
             
        }

        public async Task<User> GetUserById(long userId)
        {
            return await _db.QueryFirstOrDefaultAsync<User>("select * from users where id=@userId", new { @userId = userId });
        }

        public async Task<bool> IsEmailExists(string email)
        {
            var result = await _db.QueryFirstOrDefaultAsync("select * from users where email=@email",new {@email=email});

            return result != null ? true : false;

        }

        public async Task<User> LoginUser(LoginUserInfoQuery loginInfo)
        {
            var result = await _db.QueryFirstOrDefaultAsync<User>("select * from users where email=@email and password=@password",
                new{ @email =loginInfo.Email, @password =loginInfo.Password});

            return result;
        }

        public async Task<User> GetUserByActiveCode(string activeCode)
        {
            var result = await _db.QueryFirstOrDefaultAsync<User>("select * from users where EmailActiveCode=@emailActiveCode",new { @emailActiveCode=activeCode });
            return result;
        }
    }
}