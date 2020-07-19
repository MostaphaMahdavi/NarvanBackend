using AutoMapper;
using MediatR;
using Narvan.Domains.Commons;
using Narvan.Domains.Commons.Securities;
using Narvan.Domains.Enums;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Commands.Handlers
{
    public class AddUserCommandInfoHandler : IRequestHandler<AddUserCommandInfo, ResultStatusType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;

        public AddUserCommandInfoHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHelper passwordHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
        }

        public async Task<ResultStatusType> Handle(AddUserCommandInfo request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.Password = _passwordHelper.EncodePasswordMd5(request.Password);
            await _unitOfWork.UserRepositoryCommand.AddUser(user);
            await _unitOfWork.Save();
            return ResultStatusType.Success;

        }
    }
}