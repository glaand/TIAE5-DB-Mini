using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIAE5_DB_Mini.Models
{
    public class Mitarbeiter : Beteiligte
    {
        public int mitarbeiterId { get; set; }

        public int badgeNummer { get; set; }
        public float lohnProMonat { get; set; }

        public Beteiligte beteiligte { get; set; }
    }
}
