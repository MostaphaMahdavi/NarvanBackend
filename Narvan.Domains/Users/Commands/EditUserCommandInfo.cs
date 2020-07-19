using MediatR;
using Narvan.Domains.Commons;
using Narvan.Domains.Enums;

namespace Narvan.Domains.Users.Commands
{
    public class EditUserCommandInfo:BaseEntity,IRequest<ResultStatusType>
    {
        #region Propertise

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActivated { get; set; }

        #endregion
    }
}