using MediatR;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Queries;
using Narvan.Domains.Users.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Queries.Handlers
{
    public class LoginUserInfoQueryHandler : IRequestHandler<LoginUserInfoQuery, User>
    {
        private readonly IUserRepositoryQuery _userRepositoryQuery;

        public LoginUserInfoQueryHandler(IUserRepositoryQuery userRepositoryQuery)
        {
            _userRepositoryQuery = userRepositoryQuery;
        }

        public async Task<User> Handle(LoginUserInfoQuery request, CancellationToken cancellationToken)
        {
            return await _userRepositoryQuery.LoginUser(request);
        }
    }
}