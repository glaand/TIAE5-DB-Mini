using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIAE5_DB_Mini.Models
{
    public class Objekt
    {
        public int objektId { get; set; }

        public double laengengrad { get; set; }
        public double breitengrad { get; set; }
        public double laenge { get; set; }
        public double breite { get; set; }
        public double flache { get; set; }

        public List<Gefaehrdung> gefaehrdung { get; set; }
  }
}
