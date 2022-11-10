using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVacination.Domaine
{
    public class Vaccin
    {
        [DataType(DataType.Date)]
        public DateTime DateValidite { get; set; }
        public String Fournisseur { get; set; }
        public int Quantite { get; set; }
        public TypeVaccin TypeVaccin { get; set; }
        [Key]
        public int VaccinId { get; set; }

        //public virtual ICollection<Citoyen> Citoy { get; set; }
        public virtual ICollection<RendezVous> RendezVous { get; set; }

        public virtual CentreVaccination CentreVaccination { get; set; }



       
    }
    public enum TypeVaccin
    {
        PFizer,
        Moderna,
        Jhonson
    }
}
