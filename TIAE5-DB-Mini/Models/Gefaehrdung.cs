using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIAE5_DB_Mini.Models
{
    public class Gefaehrdung
    {
        public int gefaehrdungId { get; set; }

        public UInt16 gefaehrdungsstufe { get; set; }
        public String beschreibung { get; set; }
        public bool hatVerfuegung { get; set; }

        public List<Beteiligte> beteiligte { get; set; }
  }
}
