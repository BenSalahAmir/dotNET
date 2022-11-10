using AM.Infrastructure.Configuration;
using GestionDeVacination.Domaine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DBcontex:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=VaccinAmirBenSalah;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RendezVousConfiguration());
            modelBuilder.Entity<Citoyen>().OwnsOne(e => e.Addresse);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Citoyen> citoyen { get; set; }
        public DbSet<Vaccin> vaccin { get; set; }

        public DbSet<RendezVous> RendezVous { get; set; }
        public DbSet<CentreVaccination> CentreVaccination { get; set; }


    }
}
