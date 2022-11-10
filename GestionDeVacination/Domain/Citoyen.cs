using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVacination.Domaine
{
    public class Citoyen
    {
       
        public int Age { get; set; }

   
        public String CIN { get; set; }
        [Key]
        public int CitoyenId { get; set; }
        public String Nom { get; set; }

        [Required]
        public int NumeroEvax { get; set; }

        public String Prenom { get; set; }

        public int Telephone { get; set; }
        public Addresse Addresse { get; set; }

      //  public virtual ICollection<Vaccin> Vaccins { get; set; }

        public virtual ICollection<RendezVous> RendezVous { get; set; }


        public override string? ToString()
        {
            return ("votre age est" + Age);
        }
    }
}
