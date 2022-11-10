using GestionDeVacination.Domaine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class RendezVousConfiguration : IEntityTypeConfiguration<RendezVous>
    {
        public void Configure(EntityTypeBuilder<RendezVous> builder)
        {
             builder.HasKey(e => new { e.CitoyenId,e.VaccinId,e.DateVaccination});
            builder.HasOne(v => v.Vaccins)
                .WithMany(r => r.RendezVous)
                .HasForeignKey(v => v.VaccinId);

            builder.HasOne(c=>c.Citoyens)
                .WithMany(r => r.RendezVous)
                .HasForeignKey(c => c.CitoyenId);

            // builder.HasKey(e => new { e.Citoyen.CitoyenId,e.Vaccin.VaccinId,e.DateVaccination});


        }
    }
}
