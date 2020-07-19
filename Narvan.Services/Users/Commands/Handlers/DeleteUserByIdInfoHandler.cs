using MediatR;
using Narvan.Domains.Commons;
using Narvan.Domains.Enums;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Commands.Handlers
{
    public class DeleteUserByIdInfoHandler : IRequestHandler<DeleteUserByIdInfo, ResultStatusType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepositoryQuery _query;

        public DeleteUserByIdInfoHandler(IUnitOfWork unitOfWork, IUserRepositoryQuery query)
        {
            _unitOfWork = unitOfWork;
            _query = query;
        }

        public async Task<ResultStatusType> Handle(DeleteUserByIdInfo request, CancellationToken cancellationToken)
        {
            var user = await _query.GetUserById(request.Id);
            _unitOfWork.UserRepositoryCommand.RemoveUser(user);
            await _unitOfWork.Save();
            return ResultStatusType.Success;
        }
    }
}