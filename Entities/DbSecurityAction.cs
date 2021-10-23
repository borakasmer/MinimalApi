using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class DbSecurityAction
    {
        public int IdSecurityAction { get; set; }
        public long? ActionNumber { get; set; }
        public string ActionName { get; set; }
        public int? IdSecurityController { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string Client { get; set; }
        public string ClientIp { get; set; }
        public bool Deleted { get; set; }
        public bool? OpenStatus { get; set; }
        public int? OpenStatusUserId { get; set; }

        public virtual DbSecurityController IdSecurityControllerNavigation { get; set; }
    }
}
