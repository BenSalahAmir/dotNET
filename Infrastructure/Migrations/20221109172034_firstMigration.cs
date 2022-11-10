using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentreVaccination",
                columns: table => new
                {
                    CentreVaccinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NbChaisie = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<int>(type: "int", nullable: false),
                    ResponsableCentre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreVaccination", x => x.CentreVaccinationId);
                });

            migrationBuilder.CreateTable(
                name: "citoyen",
                columns: table => new
                {
                    CitoyenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroEvax = table.Column<int>(type: "int", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    AddresseCodePostal = table.Column<int>(name: "Addresse_CodePostal", type: "int", nullable: false),
                    AddresseVille = table.Column<string>(name: "Addresse_Ville", type: "nvarchar(max)", nullable: false),
                    AddresseRue = table.Column<int>(name: "Addresse_Rue", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citoyen", x => x.CitoyenId);
                });

            migrationBuilder.CreateTable(
                name: "vaccin",
                columns: table => new
                {
                    VaccinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateValidite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    TypeVaccin = table.Column<int>(type: "int", nullable: false),
                    CentreVaccinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccin", x => x.VaccinId);
                    table.ForeignKey(
                        name: "FK_vaccin_CentreVaccination_CentreVaccinationId",
                        column: x => x.CentreVaccinationId,
                        principalTable: "CentreVaccination",
                        principalColumn: "CentreVaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    DateVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinId = table.Column<int>(type: "int", nullable: false),
                    CitoyenId = table.Column<int>(type: "int", nullable: false),
                    CodeInfirmiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbresDoses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => new { x.CitoyenId, x.VaccinId, x.DateVaccination });
                    table.ForeignKey(
                        name: "FK_RendezVous_citoyen_CitoyenId",
                        column: x => x.CitoyenId,
                        principalTable: "citoyen",
                        principalColumn: "CitoyenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_vaccin_VaccinId",
                        column: x => x.VaccinId,
                        principalTable: "vaccin",
                        principalColumn: "VaccinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_VaccinId",
                table: "RendezVous",
                column: "VaccinId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccin_CentreVaccinationId",
                table: "vaccin",
                column: "CentreVaccinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "citoyen");

            migrationBuilder.DropTable(
                name: "vaccin");

            migrationBuilder.DropTable(
                name: "CentreVaccination");
        }
    }
}
