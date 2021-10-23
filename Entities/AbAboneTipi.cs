using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class AbAboneTipi
    {
        public AbAboneTipi()
        {
            AbAbone = new HashSet<AbAbone>();
        }

        public int IdAboneTipi { get; set; }
        public string AboneTipiAdi { get; set; }
        public int? IdAboneTipiGib { get; set; }
        public string SabitAl { get; set; }
        public bool SahaKontrol { get; set; }
        public bool ResmiDaire { get; set; }
        public int IdAboneSektor { get; set; }

        public virtual ICollection<AbAbone> AbAbone { get; set; }
    }
}
