// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DBcontex))]
    [Migration("20221109172034_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionDeVacination.Domaine.CentreVaccination", b =>
                {
                    b.Property<int>("CentreVaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CentreVaccinationId"));

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<int>("NbChaisie")
                        .HasColumnType("int");

                    b.Property<int>("NumTelephone")
                        .HasColumnType("int");

                    b.Property<string>("ResponsableCentre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CentreVaccinationId");

                    b.ToTable("CentreVaccination");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.Citoyen", b =>
                {
                    b.Property<int>("CitoyenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitoyenId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroEvax")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("CitoyenId");

                    b.ToTable("citoyen");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.RendezVous", b =>
                {
                    b.Property<int>("CitoyenId")
                        .HasColumnType("int");

                    b.Property<int>("VaccinId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateVaccination")
                        .HasColumnType("datetime2");

                    b.Property<string>("CodeInfirmiere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbresDoses")
                        .HasColumnType("int");

                    b.HasKey("CitoyenId", "VaccinId", "DateVaccination");

                    b.HasIndex("VaccinId");

                    b.ToTable("RendezVous");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.Vaccin", b =>
                {
                    b.Property<int>("VaccinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccinId"));

                    b.Property<int>("CentreVaccinationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateValidite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<int>("TypeVaccin")
                        .HasColumnType("int");

                    b.HasKey("VaccinId");

                    b.HasIndex("CentreVaccinationId");

                    b.ToTable("vaccin");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.Citoyen", b =>
                {
                    b.OwnsOne("GestionDeVacination.Domaine.Addresse", "Addresse", b1 =>
                        {
                            b1.Property<int>("CitoyenId")
                                .HasColumnType("int");

                            b1.Property<int>("CodePostal")
                                .HasColumnType("int");

                            b1.Property<int>("Rue")
                                .HasColumnType("int");

                            b1.Property<string>("Ville")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CitoyenId");

                            b1.ToTable("citoyen");

                            b1.WithOwner()
                                .HasForeignKey("CitoyenId");
                        });

                    b.Navigation("Addresse")
                        .IsRequired();
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.RendezVous", b =>
                {
                    b.HasOne("GestionDeVacination.Domaine.Citoyen", "Citoyens")
                        .WithMany("RendezVous")
                        .HasForeignKey("CitoyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeVacination.Domaine.Vaccin", "Vaccins")
                        .WithMany("RendezVous")
                        .HasForeignKey("VaccinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citoyens");

                    b.Navigation("Vaccins");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.Vaccin", b =>
                {
                    b.HasOne("GestionDeVacination.Domaine.CentreVaccination", "CentreVaccination")
                        .WithMany("Vaccins")
                        .HasForeignKey("CentreVaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentreVaccination");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.CentreVaccination", b =>
                {
                    b.Navigation("Vaccins");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.Citoyen", b =>
                {
                    b.Navigation("RendezVous");
                });

            modelBuilder.Entity("GestionDeVacination.Domaine.Vaccin", b =>
                {
                    b.Navigation("RendezVous");
                });
#pragma warning restore 612, 618
        }
    }
}
