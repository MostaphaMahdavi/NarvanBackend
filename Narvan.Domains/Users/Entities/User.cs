using System.Collections.Generic;
using Narvan.Domains.Commons;
using Narvan.Domains.UserRoles.Entities;

namespace Narvan.Domains.Users.Entities
{
    public class User:BaseEntity
    {
        #region Propertise

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailActiveCode { get; set; }
        public string Password { get; set; }
        public bool IsActivated { get; set; }

        #endregion

        #region Relations

        public List<UserRole> UserRoles { get; set; }
        
        #endregion
    }
}