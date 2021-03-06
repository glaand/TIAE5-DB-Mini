using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Drawing.Printing;
using System.Collections.Generic;

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

            modelBuilder.Entity<Gefaehrdung>(entity => {
              entity.HasCheckConstraint("CK_Gefaehrdung_Stufe", "[gefaehrdungsstufe] > 0 AND [gefaehrdungsstufe] <= 10");
            });

            modelBuilder.Entity<Objekt>(entity => {
              entity.HasCheckConstraint("CK_Objekt_Laengengrad", "[laengengrad] >= -180 AND [laengengrad] <= 180");
              entity.HasCheckConstraint("CK_Objekt_Breitengrad", "[breitengrad] >= -90 AND [breitengrad] <= 90");
              entity.HasCheckConstraint("CK_Objekt_Laenge", "[laenge] > 0");
              entity.HasCheckConstraint("CK_Objekt_Breite", "[breite] > 0");
              entity.HasCheckConstraint("CK_Objekt_Flache", "[flache] > 0");
            });

            modelBuilder.Entity<Gefaehrdung>(entity => entity.HasCheckConstraint("CK_Gefaehrdung_Stufe_Min", "[gefaehrdungsstufe] > 0"));
            modelBuilder.Entity<Gefaehrdung>(entity => entity.HasCheckConstraint("CK_Gefaehrdung_Stufe_Max", "[gefaehrdungsstufe] <= 0"));

            var beteiligte1 = new { beteiligteId = 1, vorname = "Sven", nachname = "Gehring", objektId = 1 };
            var beteiligte2 = new { beteiligteId = 2, vorname = "André", nachname = "Glatzl", objektId = 2 };
            var beteiligte3 = new { beteiligteId = 3, vorname = "Lukas", nachname = "Müller", objektId = 3 };

            var objekt1 = new { objektId = 1, laengengrad = 90.0, breitengrad = 90.0, laenge = 100.0, breite = 80, flache = 120 };
            var objekt2 = new { objektId = 2, laengengrad = 80.0, breitengrad = 80.0, laenge = 110.0, breite = 90, flache = 130 };
            var objekt3 = new { objektId = 3, laengengrad = 70.0, breitengrad = 70.0, laenge = 120.0, breite = 100, flache = 140 };

            var eigentumer1 = new { juristischePerson = true, beteiligteId = 1, eigentuemerId = 1, vorname = "Sven", nachname = "Gehring", objektId = 1 } ;
            var eigentumer2 = new { juristischePerson = false, beteiligteId = 2, eigentuemerId = 2, vorname = "André", nachname = "Glatzl", objektId = 2 };
            var eigentumer3 = new { juristischePerson = false, beteiligteId = 3, eigentuemerId = 3, vorname = "Lukas", nachname = "Müller", objektId = 3 };

            var gefaehrdung1 = new { gefaehrdungId = 1, gefaehrdungsstufe = 1, beschreibung = "bla", hatVerfuegung = true, objektId = 1 };
            var gefaehrdung2 = new { gefaehrdungId = 2, gefaehrdungsstufe = 2, beschreibung = "bla bla", hatVerfuegung = false, objektId = 2 };
            var gefaehrdung3 = new { gefaehrdungId = 3, gefaehrdungsstufe = 3, beschreibung = "bla bla bla", hatVerfuegung = true, objektId = 3 };

            var grundbuchamt1 = new { amtskennung = "ZH Hochbau" };
            var grundbuchamt2 = new { amtskennung = "AG Hochbau" };
            var grundbuchamt3 = new { amtskennung = "GR Hochbau" };

            var mitarbeiter1 = new { badgeNummer = 1000, lohnProMonat = 5000 };
            var mitarbeiter2 = new { badgeNummer = 1200, lohnProMonat = 6000 };
            var mitarbeiter3 = new { badgeNummer = 1400, lohnProMonat = 7000 };



            modelBuilder.Entity<Beteiligte>().HasData(beteiligte1, beteiligte2, beteiligte3);
            modelBuilder.Entity<Objekt>().HasData(objekt1, objekt2, objekt3);
            modelBuilder.Entity<Eigentuemer>().HasData(eigentumer1, eigentumer2, eigentumer3);
            modelBuilder.Entity<Gefaehrdung>().HasData(gefaehrdung1, gefaehrdung2, gefaehrdung3);
            modelBuilder.Entity<Grundbuchamt>().HasData(grundbuchamt1, grundbuchamt2, grundbuchamt3);
            modelBuilder.Entity<Mitarbeiter>().HasData(mitarbeiter1, mitarbeiter2, mitarbeiter3);

        }
    }
}
