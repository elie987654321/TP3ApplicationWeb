using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "utilisateurs",
                columns: table => new
                {
                    UtilisateurID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateurs", x => x.UtilisateurID);
                });

            migrationBuilder.CreateTable(
                name: "evaluations",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false),
                    Cote = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JeuID = table.Column<int>(type: "int", nullable: true),
                    UtilisateurID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluations", x => x.EvaluationID);
                    table.ForeignKey(
                        name: "FK_evaluations_utilisateurs_UtilisateurID",
                        column: x => x.UtilisateurID,
                        principalTable: "utilisateurs",
                        principalColumn: "UtilisateurID");
                });

            migrationBuilder.CreateTable(
                name: "jeux",
                columns: table => new
                {
                    JeuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDuJeu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDeJeu = table.Column<int>(type: "int", nullable: false),
                    EvaluationID = table.Column<int>(type: "int", nullable: false),
                    DateProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extrait = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilisateurID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jeux", x => x.JeuID);
                    table.ForeignKey(
                        name: "FK_jeux_evaluations_EvaluationID",
                        column: x => x.EvaluationID,
                        principalTable: "evaluations",
                        principalColumn: "EvaluationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jeux_utilisateurs_UtilisateurID",
                        column: x => x.UtilisateurID,
                        principalTable: "utilisateurs",
                        principalColumn: "UtilisateurID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_JeuID",
                table: "evaluations",
                column: "JeuID");

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_UtilisateurID",
                table: "evaluations",
                column: "UtilisateurID");

            migrationBuilder.CreateIndex(
                name: "IX_jeux_EvaluationID",
                table: "jeux",
                column: "EvaluationID");

            migrationBuilder.CreateIndex(
                name: "IX_jeux_UtilisateurID",
                table: "jeux",
                column: "UtilisateurID");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluations_jeux_JeuID",
                table: "evaluations",
                column: "JeuID",
                principalTable: "jeux",
                principalColumn: "JeuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluations_jeux_JeuID",
                table: "evaluations");

            migrationBuilder.DropTable(
                name: "jeux");

            migrationBuilder.DropTable(
                name: "evaluations");

            migrationBuilder.DropTable(
                name: "utilisateurs");
        }
    }
}
