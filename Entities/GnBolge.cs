using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class GnBolge
    {
        public GnBolge()
        {
            AbAbone = new HashSet<AbAbone>();
        }

        public int IdBolge { get; set; }
        public string BolgeKodu { get; set; }
        public string BolgeAdi { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaKisaAdi { get; set; }
        public string Vkn { get; set; }
        public string EfaturaIban { get; set; }

        public virtual ICollection<AbAbone> AbAbone { get; set; }
    }
}
