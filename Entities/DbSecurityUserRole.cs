using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class DbSecurityUserRole
    {
        public int IdSecurityUserRole { get; set; }
        public int IdSecurityRole { get; set; }
        public int? IdSecurityController { get; set; }
        public long? ActionNumberTotal { get; set; }
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string Client { get; set; }
        public string ClientIp { get; set; }
        public bool? Deleted { get; set; }

        public virtual DbSecurityController IdSecurityControllerNavigation { get; set; }
        public virtual DbSecurityRole IdSecurityRoleNavigation { get; set; }
    }
}
