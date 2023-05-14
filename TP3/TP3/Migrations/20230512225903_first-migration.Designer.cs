﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP3.Models;

#nullable disable

namespace TP3.Migrations
{
    [DbContext(typeof(BD))]
    [Migration("20230512225903_first-migration")]
    partial class firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TP3.Models.Evaluation", b =>
                {
                    b.Property<int>("EvaluationID")
                        .HasColumnType("int");

                    b.Property<int>("Cote")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JeuID")
                        .HasColumnType("int");

                    b.Property<string>("UtilisateurID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EvaluationID");

                    b.HasIndex("JeuID");

                    b.HasIndex("UtilisateurID");

                    b.ToTable("evaluations");
                });

            modelBuilder.Entity("TP3.Models.Jeu", b =>
                {
                    b.Property<int>("JeuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JeuID"));

                    b.Property<string>("Auteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateProduction")
                        .HasColumnType("datetime2");

                    b.Property<string>("Duree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvaluationID")
                        .HasColumnType("int");

                    b.Property<string>("Extrait")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomDuJeu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeDeJeu")
                        .HasColumnType("int");

                    b.Property<string>("UtilisateurID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("JeuID");

                    b.HasIndex("EvaluationID");

                    b.HasIndex("UtilisateurID");

                    b.ToTable("jeux");
                });

            modelBuilder.Entity("TP3.Models.Utilisateur", b =>
                {
                    b.Property<string>("UtilisateurID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UtilisateurID");

                    b.ToTable("utilisateurs");
                });

            modelBuilder.Entity("TP3.Models.Evaluation", b =>
                {
                    b.HasOne("TP3.Models.Jeu", null)
                        .WithMany("evaluations")
                        .HasForeignKey("JeuID");

                    b.HasOne("TP3.Models.Utilisateur", null)
                        .WithMany("Evaluations")
                        .HasForeignKey("UtilisateurID");
                });

            modelBuilder.Entity("TP3.Models.Jeu", b =>
                {
                    b.HasOne("TP3.Models.Evaluation", "Evaluation")
                        .WithMany()
                        .HasForeignKey("EvaluationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP3.Models.Utilisateur", null)
                        .WithMany("Favoris")
                        .HasForeignKey("UtilisateurID");

                    b.Navigation("Evaluation");
                });

            modelBuilder.Entity("TP3.Models.Jeu", b =>
                {
                    b.Navigation("evaluations");
                });

            modelBuilder.Entity("TP3.Models.Utilisateur", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("Favoris");
                });
#pragma warning restore 612, 618
        }
    }
}