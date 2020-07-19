using System.Collections.Generic;
using Narvan.Domains.Commons;
using Narvan.Domains.UserRoles.Entities;

namespace Narvan.Domains.Roles.Entities
{
    public class Role:BaseEntity
    {

        #region Propertise

        public string Name { get; set; }

        public string Title { get; set; }

        #endregion

        #region Relations

        public List<UserRole> UserRoles { get; set; }
        

        #endregion

    }
}