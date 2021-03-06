using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIAE5_DB_Mini.Models
{
    public class Eigentuemer
    {
        public int eigentuemerId { get; set; }

        public bool juristischePerson { get; set; }

        public Beteiligte beteiligte { get; set; }
    }
}
