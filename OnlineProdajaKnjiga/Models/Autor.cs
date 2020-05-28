using System;
using System.Collections.Generic;

namespace OnlineProdajaKnjiga.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Knjiga = new HashSet<Knjiga>();
        }

        public long IdAutor { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? BrojDijela { get; set; }
        public string Biografija { get; set; }

        public string FullName
        {
            get
            {
                return Ime + " " + Prezime;
            }
        }


        public virtual ICollection<Knjiga> Knjiga { get; set; }
    }
}
