using Narvan.Domains.Commons;
using Narvan.Domains.Roles.Entities;
using Narvan.Domains.Users.Entities;

namespace Narvan.Domains.UserRoles.Entities
{
    public class UserRole:BaseEntity
    {

        #region Propertise

        public long UserId { get; set; }

        public long RoleId { get; set; }


        #endregion


        #region Relations

        public User User { get; set; }

        public Role Role { get; set; }

        #endregion

    }
}