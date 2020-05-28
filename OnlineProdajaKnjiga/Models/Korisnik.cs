using System;
using System.Collections.Generic;

namespace OnlineProdajaKnjiga.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Narudzba = new HashSet<Narudzba>();
        }

        public long IdKorisnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? BrojMobitela { get; set; }
        public long FkMjesto { get; set; }

        public virtual Mjesto FkMjestoNavigation { get; set; }
        public virtual ICollection<Narudzba> Narudzba { get; set; }
    }
}
