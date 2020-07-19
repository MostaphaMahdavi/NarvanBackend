using MediatR;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Enums;

namespace Narvan.Domains.Users.Queries
{
    public class LoginUserInfoQuery:IRequest<User>
    {
        #region Propertise

        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        #endregion
    }
}