using MediatR;
using Narvan.Domains.Enums;

namespace Narvan.Domains.Users.Commands
{
    public class ActiveUserInfo:IRequest<ResultStatusType>
    {
        public string EmailActiveCode { get; set; }

        public ActiveUserInfo(string emailActiveCode)
        {
            EmailActiveCode = emailActiveCode;
        }
    }
}