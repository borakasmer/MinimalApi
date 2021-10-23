using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class DbSecurityController
    {
        public DbSecurityController()
        {
            DbSecurityAction = new HashSet<DbSecurityAction>();
            DbSecurityUserAction = new HashSet<DbSecurityUserAction>();
            DbSecurityUserRole = new HashSet<DbSecurityUserRole>();
        }

        public int IdSecurityController { get; set; }
        public string ControllerName { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string Client { get; set; }
        public string ClientIp { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<DbSecurityAction> DbSecurityAction { get; set; }
        public virtual ICollection<DbSecurityUserAction> DbSecurityUserAction { get; set; }
        public virtual ICollection<DbSecurityUserRole> DbSecurityUserRole { get; set; }
    }
}
