using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class DbMenu
    {
        public int IdMenu { get; set; }
        public int OrderNumber { get; set; }
        public string MenuName { get; set; }
        public int? IdSecurityController { get; set; }
        public long? ActionNumber { get; set; }
        public string RoutingPath { get; set; }
        public string ImageClass { get; set; }
        public int IdMenuParent { get; set; }
        public bool IsParent { get; set; }
        public bool HasChild { get; set; }
        public bool IsActive { get; set; }
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string Client { get; set; }
        public string ClientIp { get; set; }
        public bool Deleted { get; set; }
    }
}
