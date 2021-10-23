using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class DbRole
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string Client { get; set; }
        public string ClientIp { get; set; }
        public bool Deleted { get; set; }
    }
}
