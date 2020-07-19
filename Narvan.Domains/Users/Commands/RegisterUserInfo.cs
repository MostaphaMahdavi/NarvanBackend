using MediatR;
using Narvan.Domains.Users.Enums;

namespace Narvan.Domains.Users.Commands
{
    public class RegisterUserInfo:IRequest<RegisterUserResult>
    {
        #region Propertise

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string EmailActiveCode { get; set; }

        #endregion
    }
}