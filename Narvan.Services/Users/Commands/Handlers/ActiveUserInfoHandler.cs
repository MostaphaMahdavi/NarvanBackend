using MediatR;
using Narvan.Domains.Commons;
using Narvan.Domains.Enums;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Commands.Handlers
{
    public class ActiveUserInfoHandler : IRequestHandler<ActiveUserInfo, ResultStatusType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepositoryQuery _userRepositoryQuery;

        public ActiveUserInfoHandler(IUnitOfWork unitOfWork, IUserRepositoryQuery userRepositoryQuery)
        {
            _unitOfWork = unitOfWork;
            _userRepositoryQuery = userRepositoryQuery;
        }

        public async Task<ResultStatusType> Handle(ActiveUserInfo request, CancellationToken cancellationToken)
        {
            var user = await _userRepositoryQuery.GetUserByActiveCode(request.EmailActiveCode);
            user.EmailActiveCode = Generator.GenerateGuid();
            user.IsActivated = true;
            _unitOfWork.UserRepositoryCommand.UpdateUser(user);
            await _unitOfWork.Save();
            return ResultStatusType.Success;
        }
    }
}