using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIAE5_DB_Mini.Models
{
    public class Beteiligte
    {
        public int beteiligteId { get; set; }

        public String vorname { get; set; }
        public String nachname { get; set; }

        public List<Objekt> objekt { get; set; }
    }
}
