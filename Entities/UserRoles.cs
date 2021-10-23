using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class UserRoles
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleGroupId { get; set; }
        public long? Roles { get; set; }

        public virtual RoleGroups RoleGroup { get; set; }
        public virtual Users User { get; set; }
    }
}
