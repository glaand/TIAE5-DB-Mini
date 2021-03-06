using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIAE5_DB_Mini.Models
{
    [Table("mitarbeiter")]
    public class Mitarbeiter : Beteiligte
    {
        public int mitarbeiterId { get; set; }

        [Required]
        public int badgeNummer { get; set; }

        [Required]
        public float lohnProMonat { get; set; }

        public Beteiligte beteiligte { get; set; }
    }
}
