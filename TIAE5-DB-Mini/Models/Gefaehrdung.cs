using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIAE5_DB_Mini.Models
{
    public class Gefaehrdung
    {
        public int gefaehrdungId { get; set; }

        [Required]
        public UInt16 gefaehrdungsstufe { get; set; }

        [Required]
        public String beschreibung { get; set; }

        [Required]
        public bool hatVerfuegung { get; set; }
  }
}
