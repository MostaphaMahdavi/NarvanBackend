using MediatR;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Enums;
using Narvan.Domains.Users.Repositories;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Commands.Behaviors
{
    public class EmailExistBehavior<T, TR> : IPipelineBehavior<RegisterUserInfo, RegisterUserResult>
    {
        private readonly IUserRepositoryQuery _query;

        public EmailExistBehavior(IUserRepositoryQuery query)
        {
            _query = query;
        }
        public async Task<RegisterUserResult> Handle(RegisterUserInfo request, CancellationToken cancellationToken, RequestHandlerDelegate<RegisterUserResult> next)
        {

            if (await _query.IsEmailExists(request.Email.Trim().ToLower()))
            {
                Log.ForContext("Message", request)
                    .ForContext("Error", "EmailIsExist").Error($"Error: ** {request}");

                return RegisterUserResult.EmailExists;
            }

            return await next();
        }
    }
}