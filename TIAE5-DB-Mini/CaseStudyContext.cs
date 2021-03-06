using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Drawing.Printing;

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
              entity.HasCheckConstraint("CK_Objekt_Laengengrad", "[laengengrad] >= -180 AND [laengengrad] <= 80");
              entity.HasCheckConstraint("CK_Objekt_Breitengrad", "[breitengrad] >= -90 AND [breitengrad] <= 90");
              entity.HasCheckConstraint("CK_Objekt_Laenge", "[laenge] > 0");
              entity.HasCheckConstraint("CK_Objekt_Breite", "[breite] > 0");
              entity.HasCheckConstraint("CK_Objekt_Flache", "[flache] > 0");
            });
        }
    }
}
