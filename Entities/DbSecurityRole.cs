using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class DbSecurityRole
    {
        public DbSecurityRole()
        {
            DbSecurityUserRole = new HashSet<DbSecurityUserRole>();
            DbUser = new HashSet<DbUser>();
            DbUser2 = new HashSet<DbUser2>();
            DbUser2017 = new HashSet<DbUser2017>();
            DbUser2018 = new HashSet<DbUser2018>();
            DbUser2019 = new HashSet<DbUser2019>();
        }

        public int IdSecurityRole { get; set; }
        public string SecurityRoleName { get; set; }
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string Client { get; set; }
        public string ClientIp { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<DbSecurityUserRole> DbSecurityUserRole { get; set; }
        public virtual ICollection<DbUser> DbUser { get; set; }
        public virtual ICollection<DbUser2> DbUser2 { get; set; }
        public virtual ICollection<DbUser2017> DbUser2017 { get; set; }
        public virtual ICollection<DbUser2018> DbUser2018 { get; set; }
        public virtual ICollection<DbUser2019> DbUser2019 { get; set; }
    }
}
