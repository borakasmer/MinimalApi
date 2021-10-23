using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class AbAbone
    {
        public decimal IdAbone { get; set; }
        public decimal AboneNo { get; set; }
        public decimal SozlesmeNo { get; set; }
        public int IdAboneGrubu { get; set; }
        public int IdAboneTipi { get; set; }
        public int IdSozlesmeTipi { get; set; }
        public int IdBolge { get; set; }
        public string KimlikNo { get; set; }
        public string AboneAdi { get; set; }
        public string AboneSoyadi { get; set; }
        public DateTime? SozlesmeBaslangicTarihi { get; set; }
        public DateTime? SozlesmeBitisTarihi { get; set; }
        public bool MalSahibi { get; set; }
        public string AcikAdres { get; set; }

        public virtual AbAboneTipi IdAboneTipiNavigation { get; set; }
        public virtual GnBolge IdBolgeNavigation { get; set; }
        public virtual GnSozlesmeTipi IdSozlesmeTipiNavigation { get; set; }
    }
}
