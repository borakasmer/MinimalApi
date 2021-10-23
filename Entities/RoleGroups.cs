using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class RoleGroups
    {
        public RoleGroups()
        {
            Roles = new HashSet<Roles>();
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
