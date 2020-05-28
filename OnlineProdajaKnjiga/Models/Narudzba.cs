using System;
using System.Collections.Generic;

namespace OnlineProdajaKnjiga.Models
{
    public partial class Narudzba
    {
        public Narudzba()
        {
            NarudzbaKnjiga = new HashSet<NarudzbaKnjiga>();
        }

        public long IdNarudzba { get; set; }
        public long FkKorisnk { get; set; }
        public DateTime? DatumNarudzbe { get; set; }
        public float? UkupnaCijena { get; set; }
        public bool? Dostava { get; set; }

        public virtual Korisnik FkKorisnkNavigation { get; set; }
        public virtual ICollection<NarudzbaKnjiga> NarudzbaKnjiga { get; set; }
    }
}
