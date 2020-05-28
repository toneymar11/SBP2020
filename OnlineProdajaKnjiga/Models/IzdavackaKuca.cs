using System;
using System.Collections.Generic;

namespace OnlineProdajaKnjiga.Models
{
    public partial class IzdavackaKuca
    {
        public IzdavackaKuca()
        {
            Knjiga = new HashSet<Knjiga>();
        }

        public long IdIzdavackaKuca { get; set; }
        public string Naziv { get; set; }
        public long FkMjesto { get; set; }

        public virtual Mjesto FkMjestoNavigation { get; set; }
        public virtual ICollection<Knjiga> Knjiga { get; set; }
    }
}
