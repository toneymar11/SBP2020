using System;
using System.Collections.Generic;

namespace OnlineProdajaKnjiga.Models
{
    public partial class Mjesto
    {
        public Mjesto()
        {
            IzdavackaKuca = new HashSet<IzdavackaKuca>();
            Korisnik = new HashSet<Korisnik>();
        }

        public long IdMjesto { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public int? PostanskiBroj { get; set; }
        public string Drzava { get; set; }

        public virtual ICollection<IzdavackaKuca> IzdavackaKuca { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
