using MediatR;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Enums;
using Narvan.Domains.Users.Repositories;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Commands.Behaviors
{
    public class UserExistByActiveCodeBehavior<T, TR> : IPipelineBehavior<ActiveUserInfo, RegisterUserResult>
    {
        private readonly IUserRepositoryQuery _userRepositoryQuery;

        public UserExistByActiveCodeBehavior(IUserRepositoryQuery userRepositoryQuery)
        {
            _userRepositoryQuery = userRepositoryQuery;
        }
        public async Task<RegisterUserResult> Handle(ActiveUserInfo request, CancellationToken cancellationToken, RequestHandlerDelegate<RegisterUserResult> next)
        {
            if (await _userRepositoryQuery.GetUserByActiveCode(request.EmailActiveCode) != null)
            {
                Log.ForContext("Message", request)
                    .ForContext("Error", "UserIsExist").Error($"Error: ** {request}");

                return RegisterUserResult.UserIsExists;
            }


            return await next();
        }
    }
}