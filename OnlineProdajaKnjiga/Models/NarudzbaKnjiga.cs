using System;
using System.Collections.Generic;

namespace OnlineProdajaKnjiga.Models
{
    public partial class NarudzbaKnjiga
    {
        public long IdNarudzbaKnjiga { get; set; }
        public long FkNarudzba { get; set; }
        public long FkKnjiga { get; set; }
        public int? Kolicina { get; set; }
        public float? Cijena { get; set; }

        public virtual Knjiga FkKnjigaNavigation { get; set; }
        public virtual Narudzba FkNarudzbaNavigation { get; set; }
    }
}
