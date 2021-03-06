using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIAE5_DB_Mini.Models
{
    public class Objekt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int objektId { get; set; }

        public double laengengrad { get; set; }
        public double breitengrad { get; set; }
        public double laenge { get; set; }
        public double breite { get; set; }
        public double flache { get; set; }

        public ICollection<Gefaehrdung> gefaehrdungs { get; set; }
        public ICollection<Beteiligte> beteiligtes { get; set; }
  }
}
