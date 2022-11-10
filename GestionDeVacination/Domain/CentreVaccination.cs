using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVacination.Domaine
{
    public class CentreVaccination
    {
        public int Capacite { get; set; }   
        public int CentreVaccinationId { get; set; }
        public int NbChaisie { get; set; }
        public int NumTelephone { get; set; }   
        public String ResponsableCentre { get; set; }
        public virtual ICollection<Vaccin> Vaccins { get; set; }
    }
}
