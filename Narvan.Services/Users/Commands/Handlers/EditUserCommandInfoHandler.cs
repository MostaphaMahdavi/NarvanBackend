using AutoMapper;
using MediatR;
using Narvan.Domains.Commons;
using Narvan.Domains.Enums;
using Narvan.Domains.Users.Commands;
using System.Threading;
using System.Threading.Tasks;
using Narvan.Domains.Users.Entities;

namespace Narvan.Services.Users.Commands.Handlers
{
    public class EditUserCommandInfoHandler : IRequestHandler<EditUserCommandInfo, ResultStatusType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditUserCommandInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResultStatusType> Handle(EditUserCommandInfo request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            _unitOfWork.UserRepositoryCommand.UpdateUser(user);
            await _unitOfWork.Save();
            return ResultStatusType.Success;
        }
    }
}