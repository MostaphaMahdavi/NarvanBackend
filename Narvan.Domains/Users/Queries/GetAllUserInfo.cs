using System.Collections.Generic;
using MediatR;
using Narvan.Domains.Commons;
using Narvan.Domains.Users.Entities;

namespace Narvan.Domains.Users.Queries
{
    public class GetAllUserInfo:BaseEntity,IRequest<List<User>>
    {
        #region Propertise

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailActiveCode { get; set; }
        public bool IsActivated { get; set; }

        #endregion
    }
}