using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineProdajaKnjiga.Models
{
    public partial class Knjiga
    {
        public Knjiga()
        {
            NarudzbaKnjiga = new HashSet<NarudzbaKnjiga>();
        }

        [Key]
        public long IdKnjiga { get; set; }
        [Required]
        public long FkAutor { get; set; }
        [Required]
        public long FkIzdavackaKuca { get; set; }
        [Required(ErrorMessage = "Morate unijeti naziv knjige")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Morate odabrati datum objave")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime DatumObjave { get; set; }
        [Required(ErrorMessage = "Morate unijeti cijenu knjige")]
        public float? Cijena { get; set; }
        [Required(ErrorMessage = "Morate unijeti broj stranica knjige")]
        public int? BrojStranica { get; set; }

       

        public virtual Autor FkAutorNavigation { get; set; }
        public virtual IzdavackaKuca FkIzdavackaKucaNavigation { get; set; }
        public virtual ICollection<NarudzbaKnjiga> NarudzbaKnjiga { get; set; }
    }
}
