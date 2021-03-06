using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
<<<<<<< HEAD
using System.Drawing.Printing;
=======
using System.Collections.Generic;
>>>>>>> Seed data

namespace TIAE5_DB_Mini.Models
{
    public class CaseStudyContext : DbContext
    {
        public CaseStudyContext(DbContextOptions options) : base(options) {}
        public DbSet<Beteiligte> beteiligtes { get; set; }
        public DbSet<Eigentuemer> eigentuemers { get; set; }
        public DbSet<Gefaehrdung> gefaehrdungs { get; set; }
        public DbSet<Grundbuchamt> grundbuchamts { get; set; }
        public DbSet<Mitarbeiter> mitarbeiters { get; set; }
        public DbSet<Objekt> objekts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD
            modelBuilder.Entity<Gefaehrdung>(entity => {
              entity.HasCheckConstraint("CK_Gefaehrdung_Stufe", "[gefaehrdungsstufe] > 0 AND [gefaehrdungsstufe] <= 10");
            });

            modelBuilder.Entity<Objekt>(entity => {
              entity.HasCheckConstraint("CK_Objekt_Laengengrad", "[laengengrad] >= -180 AND [laengengrad] <= 80");
              entity.HasCheckConstraint("CK_Objekt_Breitengrad", "[breitengrad] >= -90 AND [breitengrad] <= 90");
              entity.HasCheckConstraint("CK_Objekt_Laenge", "[laenge] > 0");
              entity.HasCheckConstraint("CK_Objekt_Breite", "[breite] > 0");
              entity.HasCheckConstraint("CK_Objekt_Flache", "[flache] > 0");
            });
=======
            modelBuilder.Entity<Gefaehrdung>(entity => entity.HasCheckConstraint("CK_Gefaehrdung_Stufe_Min", "[gefaehrdungsstufe] > 0"));
            modelBuilder.Entity<Gefaehrdung>(entity => entity.HasCheckConstraint("CK_Gefaehrdung_Stufe_Max", "[gefaehrdungsstufe] <= 0"));

            var beteiligte1 = new Beteiligte { beteiligteId = 1, vorname = "Sven", nachname = "Gehring"};
            var beteiligte2 = new Beteiligte { beteiligteId = 2, vorname = "André", nachname = "Glatzl"};
            var beteiligte3 = new Beteiligte { beteiligteId = 3, vorname = "Lukas", nachname = "Müller"};

            var objekt1 = new Objekt { objektId = 1, laengengrad = 90.0, breitengrad = 90.0, laenge = 100.0, breite = 80, flache = 120 };
            var objekt2 = new Objekt { objektId = 2, laengengrad = 80.0, breitengrad = 80.0, laenge = 110.0, breite = 90, flache = 130 };
            var objekt3 = new Objekt { objektId = 3, laengengrad = 70.0, breitengrad = 70.0, laenge = 120.0, breite = 100, flache = 140 };

            var eigentumer1 = new Eigentuemer { juristischePerson = true} ;
            var eigentumer2 = new Eigentuemer { juristischePerson = false };
            var eigentumer3 = new Eigentuemer { juristischePerson = false };

            var gefaehrdung1 = new { gefaehrdungId = 1, gefaehrdungsstufe = 1, beschreibung = "bla", hatVerfuegung = true, objektId = 1 };
            var gefaehrdung2 = new { gefaehrdungId = 2, gefaehrdungsstufe = 2, beschreibung = "bla bla", hatVerfuegung = false, objektId = 2 };
            var gefaehrdung3 = new { gefaehrdungId = 3, gefaehrdungsstufe = 3, beschreibung = "bla bla bla", hatVerfuegung = true, objektId = 3 };

            var grundbuchamt1 = new Grundbuchamt { amtskennung = "ZH Hochbau" };
            var grundbuchamt2 = new Grundbuchamt { amtskennung = "AG Hochbau" };
            var grundbuchamt3 = new Grundbuchamt { amtskennung = "GR Hochbau" };

            var mitarbeiter1 = new Mitarbeiter { badgeNummer = 1000, lohnProMonat = 5000 };
            var mitarbeiter2 = new Mitarbeiter { badgeNummer = 1200, lohnProMonat = 6000 };
            var mitarbeiter3 = new Mitarbeiter { badgeNummer = 1400, lohnProMonat = 7000 };



            modelBuilder.Entity<Beteiligte>().HasData(beteiligte1, beteiligte2, beteiligte3);
            modelBuilder.Entity<Objekt>().HasData(objekt1, objekt2, objekt3);
>>>>>>> Seed data
        }
    }
}
