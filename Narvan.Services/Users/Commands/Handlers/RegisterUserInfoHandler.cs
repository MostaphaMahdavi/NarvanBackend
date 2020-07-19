using AutoMapper;
using MediatR;
using Narvan.Domains.Commons;
using Narvan.Domains.Commons.Securities;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Enums;
using Narvan.Services.Commons.Securities;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Commands.Handlers
{
    public class RegisterUserInfoHandler : IRequestHandler<RegisterUserInfo, RegisterUserResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;

        public RegisterUserInfoHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHelper passwordHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
        }
        public async Task<RegisterUserResult> Handle(RegisterUserInfo request, CancellationToken cancellationToken)
        {
            var resultMap = _mapper.Map<User>(new RegisterUserInfo()
            {
                Address = request.Address.SanitizeText(),
                Email = request.Email.SanitizeText(),
                FirstName = request.FirstName.SanitizeText(),
                LastName = request.LastName.SanitizeText(),
                Password = _passwordHelper.EncodePasswordMd5(request.Password),
                EmailActiveCode = request.EmailActiveCode

            });
            await _unitOfWork.UserRepositoryCommand.RegisterUser(resultMap);
            await _unitOfWork.Save();
            return RegisterUserResult.Success;
        }
    }
}