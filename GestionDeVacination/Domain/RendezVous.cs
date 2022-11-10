using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVacination.Domaine
{
    public class RendezVous
    {
        public String CodeInfirmiere { get; set; } 
        public DateTime DateVaccination { get; set; }
        public int NbresDoses { get; set; }
       public int VaccinId { get; set; }
        public int CitoyenId { get; set; }

        public Citoyen Citoyens { get; set; }
        public Vaccin Vaccins { get; set; }  




        }
    }

