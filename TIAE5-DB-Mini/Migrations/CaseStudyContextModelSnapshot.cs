﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TIAE5_DB_Mini.Models;

namespace TIAE5_DB_Mini.Migrations
{
    [DbContext(typeof(CaseStudyContext))]
    partial class CaseStudyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeteiligteObjekt", b =>
                {
                    b.Property<int>("beteiligtesbeteiligteId")
                        .HasColumnType("int");

                    b.Property<int>("objektsobjektId")
                        .HasColumnType("int");

                    b.HasKey("beteiligtesbeteiligteId", "objektsobjektId");

                    b.HasIndex("objektsobjektId");

                    b.ToTable("BeteiligteObjekt");
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Beteiligte", b =>
                {
                    b.Property<int>("beteiligteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nachname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("beteiligteId");

                    b.ToTable("beteiligtes");
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Gefaehrdung", b =>
                {
                    b.Property<int>("gefaehrdungId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gefaehrdungsstufe")
                        .HasColumnType("int");

                    b.Property<bool>("hatVerfuegung")
                        .HasColumnType("bit");

                    b.Property<int?>("objektId")
                        .HasColumnType("int");

                    b.HasKey("gefaehrdungId");

                    b.HasIndex("objektId");

                    b.ToTable("gefaehrdungs");

                    b.HasCheckConstraint("CK_Gefaehrdung_Stufe", "[gefaehrdungsstufe] > 0 AND [gefaehrdungsstufe] <= 10");

                    b.HasCheckConstraint("CK_Gefaehrdung_Stufe_Min", "[gefaehrdungsstufe] > 0");

                    b.HasCheckConstraint("CK_Gefaehrdung_Stufe_Max", "[gefaehrdungsstufe] <= 10");

                    b.HasData(
                        new
                        {
                            gefaehrdungId = 1,
                            beschreibung = "bla",
                            gefaehrdungsstufe = 1,
                            hatVerfuegung = true,
                            objektId = 1
                        },
                        new
                        {
                            gefaehrdungId = 2,
                            beschreibung = "bla bla",
                            gefaehrdungsstufe = 2,
                            hatVerfuegung = false,
                            objektId = 2
                        },
                        new
                        {
                            gefaehrdungId = 3,
                            beschreibung = "bla bla bla",
                            gefaehrdungsstufe = 3,
                            hatVerfuegung = true,
                            objektId = 3
                        });
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Objekt", b =>
                {
                    b.Property<int>("objektId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("breite")
                        .HasColumnType("float");

                    b.Property<double>("breitengrad")
                        .HasColumnType("float");

                    b.Property<double>("flache")
                        .HasColumnType("float");

                    b.Property<double>("laenge")
                        .HasColumnType("float");

                    b.Property<double>("laengengrad")
                        .HasColumnType("float");

                    b.HasKey("objektId");

                    b.ToTable("objekts");

                    b.HasCheckConstraint("CK_Objekt_Laengengrad", "[laengengrad] >= -180 AND [laengengrad] <= 180");

                    b.HasCheckConstraint("CK_Objekt_Breitengrad", "[breitengrad] >= -90 AND [breitengrad] <= 90");

                    b.HasCheckConstraint("CK_Objekt_Laenge", "[laenge] > 0");

                    b.HasCheckConstraint("CK_Objekt_Breite", "[breite] > 0");

                    b.HasCheckConstraint("CK_Objekt_Flache", "[flache] > 0");

                    b.HasData(
                        new
                        {
                            objektId = 1,
                            breite = 80.0,
                            breitengrad = 90.0,
                            flache = 120.0,
                            laenge = 100.0,
                            laengengrad = 90.0
                        },
                        new
                        {
                            objektId = 2,
                            breite = 90.0,
                            breitengrad = 80.0,
                            flache = 130.0,
                            laenge = 110.0,
                            laengengrad = 80.0
                        },
                        new
                        {
                            objektId = 3,
                            breite = 100.0,
                            breitengrad = 70.0,
                            flache = 140.0,
                            laenge = 120.0,
                            laengengrad = 70.0
                        });
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Eigentuemer", b =>
                {
                    b.HasBaseType("TIAE5_DB_Mini.Models.Beteiligte");

                    b.Property<int?>("beteiligtesbeteiligteId")
                        .HasColumnType("int");

                    b.Property<bool>("juristischePerson")
                        .HasColumnType("bit");

                    b.HasIndex("beteiligtesbeteiligteId");

                    b.ToTable("eigentuemer");

                    b.HasData(
                        new
                        {
                            beteiligteId = 1,
                            nachname = "Gehring",
                            vorname = "Sven",
                            juristischePerson = true
                        });
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Grundbuchamt", b =>
                {
                    b.HasBaseType("TIAE5_DB_Mini.Models.Beteiligte");

                    b.Property<string>("amtskennung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("beteiligteId1")
                        .HasColumnType("int");

                    b.HasIndex("beteiligteId1");

                    b.ToTable("grundbuchamt");

                    b.HasData(
                        new
                        {
                            beteiligteId = 3,
                            nachname = "Müller",
                            vorname = "Lukas",
                            amtskennung = "ZH Hochbau"
                        });
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Mitarbeiter", b =>
                {
                    b.HasBaseType("TIAE5_DB_Mini.Models.Beteiligte");

                    b.Property<int>("badgeNummer")
                        .HasColumnType("int");

                    b.Property<int?>("beteiligteId1")
                        .HasColumnType("int");

                    b.Property<float>("lohnProMonat")
                        .HasColumnType("real");

                    b.HasIndex("beteiligteId1");

                    b.ToTable("mitarbeiter");

                    b.HasData(
                        new
                        {
                            beteiligteId = 2,
                            nachname = "Glatzl",
                            vorname = "André",
                            badgeNummer = 1000,
                            lohnProMonat = 5000f
                        });
                });

            modelBuilder.Entity("BeteiligteObjekt", b =>
                {
                    b.HasOne("TIAE5_DB_Mini.Models.Beteiligte", null)
                        .WithMany()
                        .HasForeignKey("beteiligtesbeteiligteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIAE5_DB_Mini.Models.Objekt", null)
                        .WithMany()
                        .HasForeignKey("objektsobjektId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Gefaehrdung", b =>
                {
                    b.HasOne("TIAE5_DB_Mini.Models.Objekt", null)
                        .WithMany("gefaehrdungs")
                        .HasForeignKey("objektId");
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Eigentuemer", b =>
                {
                    b.HasOne("TIAE5_DB_Mini.Models.Beteiligte", null)
                        .WithOne()
                        .HasForeignKey("TIAE5_DB_Mini.Models.Eigentuemer", "beteiligteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("TIAE5_DB_Mini.Models.Beteiligte", "beteiligtes")
                        .WithMany()
                        .HasForeignKey("beteiligtesbeteiligteId");

                    b.Navigation("beteiligtes");
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Grundbuchamt", b =>
                {
                    b.HasOne("TIAE5_DB_Mini.Models.Beteiligte", null)
                        .WithOne()
                        .HasForeignKey("TIAE5_DB_Mini.Models.Grundbuchamt", "beteiligteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("TIAE5_DB_Mini.Models.Beteiligte", "beteiligte")
                        .WithMany()
                        .HasForeignKey("beteiligteId1");

                    b.Navigation("beteiligte");
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Mitarbeiter", b =>
                {
                    b.HasOne("TIAE5_DB_Mini.Models.Beteiligte", null)
                        .WithOne()
                        .HasForeignKey("TIAE5_DB_Mini.Models.Mitarbeiter", "beteiligteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("TIAE5_DB_Mini.Models.Beteiligte", "beteiligte")
                        .WithMany()
                        .HasForeignKey("beteiligteId1");

                    b.Navigation("beteiligte");
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Objekt", b =>
                {
                    b.Navigation("gefaehrdungs");
                });
#pragma warning restore 612, 618
        }
    }
}
