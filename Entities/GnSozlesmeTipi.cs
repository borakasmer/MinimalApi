using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class GnSozlesmeTipi
    {
        public GnSozlesmeTipi()
        {
            AbAbone = new HashSet<AbAbone>();
        }

        public int IdSozlesmeTipi { get; set; }
        public string SozlesmeTipiAdi { get; set; }
        public string SozlesmeTipiKodu { get; set; }

        public virtual ICollection<AbAbone> AbAbone { get; set; }
    }
}
