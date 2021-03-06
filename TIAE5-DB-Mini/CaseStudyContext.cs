using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
    }
}
