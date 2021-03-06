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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vorname")
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
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Eigentuemer", b =>
                {
                    b.HasBaseType("TIAE5_DB_Mini.Models.Beteiligte");

                    b.Property<int?>("beteiligtesbeteiligteId")
                        .HasColumnType("int");

                    b.Property<int>("eigentuemerId")
                        .HasColumnType("int");

                    b.Property<bool>("juristischePerson")
                        .HasColumnType("bit");

                    b.HasIndex("beteiligtesbeteiligteId");

                    b.ToTable("eigentuemer");
                });

            modelBuilder.Entity("TIAE5_DB_Mini.Models.Grundbuchamt", b =>
                {
                    b.HasBaseType("TIAE5_DB_Mini.Models.Beteiligte");

                    b.Property<string>("amtskennung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("beteiligteId1")
                        .HasColumnType("int");

                    b.Property<int>("grundbuchamtId")
                        .HasColumnType("int");

                    b.HasIndex("beteiligteId1");

                    b.ToTable("grundbuchamt");
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

                    b.Property<int>("mitarbeiterId")
                        .HasColumnType("int");

                    b.HasIndex("beteiligteId1");

                    b.ToTable("mitarbeiter");
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
