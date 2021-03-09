using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace TIAE5_DB_Mini.Models
{
    class BeteiligteObjekt
    {
        public int beteiligtesbeteiligteId { get; set; }
        public int objektsobjektId { get; set; }
    }

    public class CaseStudyContext : DbContext
    {
        public CaseStudyContext(DbContextOptions options) : base(options) { }
        public DbSet<Beteiligte> beteiligtes { get; set; }
        public DbSet<Eigentuemer> eigentuemers { get; set; }
        public DbSet<Gefaehrdung> gefaehrdungs { get; set; }
        public DbSet<Grundbuchamt> grundbuchamts { get; set; }
        public DbSet<Mitarbeiter> mitarbeiters { get; set; }
        public DbSet<Objekt> objekts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gefaehrdung>(entity =>
            {
                entity.HasCheckConstraint("CK_Gefaehrdung_Stufe", "[gefaehrdungsstufe] > 0 AND [gefaehrdungsstufe] < 10");
            });

            modelBuilder.Entity<Objekt>(entity =>
            {
                entity.HasCheckConstraint("CK_Objekt_Laengengrad", "[laengengrad] >= -180 AND [laengengrad] <= 180");
                entity.HasCheckConstraint("CK_Objekt_Breitengrad", "[breitengrad] >= -90 AND [breitengrad] <= 90");
                entity.HasCheckConstraint("CK_Objekt_Laenge", "[laenge] > 0");
                entity.HasCheckConstraint("CK_Objekt_Breite", "[breite] > 0");
                entity.HasCheckConstraint("CK_Objekt_Flache", "[flache] > 0");
            });

            var objekt1 = new { beteiligtesbeteiligteId = 1, objektId = 1, laengengrad = (double)90.0, breitengrad = (double)90.0, laenge = (double)100.0, breite = (double)80, flache = (double)120 };
            var objekt2 = new { beteiligtesbeteiligteId = 2, objektId = 2, laengengrad = (double)80.0, breitengrad = (double)80.0, laenge = (double)110.0, breite = (double)90, flache = (double)130 };
            var objekt3 = new { beteiligtesbeteiligteId = 3, objektId = 3, laengengrad = (double)70.0, breitengrad = (double)70.0, laenge = (double)120.0, breite = (double)100, flache = (double)140 };

            var gefaehrdung1 = new { gefaehrdungId = 1, gefaehrdungsstufe = (ushort)1, beschreibung = "bla", hatVerfuegung = true, objektId = 1 };
            var gefaehrdung2 = new { gefaehrdungId = 2, gefaehrdungsstufe = (ushort)2, beschreibung = "bla bla", hatVerfuegung = false, objektId = 2 };
            var gefaehrdung3 = new { gefaehrdungId = 3, gefaehrdungsstufe = (ushort)3, beschreibung = "bla bla bla", hatVerfuegung = true, objektId = 3 };

            var eigentumer = new { beteiligteId = 1, juristischePerson = true, email = "sven@kontakt.ch", telefon = "2893748932" };
            var mitarbeiter = new { beteiligteId = 2, badgeNummer = 1000, lohnProMonat = (float)5000, email = "andre@kontakt.ch", telefon = "83274923" };
            var grundbuchamt = new { beteiligteId = 3, amtskennung = "ZH Hochbau", email = "lukas@kontakt.ch", telefon = "09349803243"};

            

            modelBuilder.Entity<Objekt>().HasData(objekt1, objekt2, objekt3);
            modelBuilder.Entity<Gefaehrdung>().HasData(gefaehrdung1, gefaehrdung2, gefaehrdung3);

            modelBuilder.Entity<Eigentuemer>().HasData(eigentumer);
            modelBuilder.Entity<Grundbuchamt>().HasData(grundbuchamt);
            modelBuilder.Entity<Mitarbeiter>().HasData(mitarbeiter);



        }
    }
}
