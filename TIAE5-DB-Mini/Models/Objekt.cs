using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TIAE5_DB_Mini.Models
{
    public class Objekt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int objektId { get; set; }

        [Required]
        public double laengengrad { get; set; }

        [Required]
        public double breitengrad { get; set; }

        [Required] 
        public double laenge { get; set; }

        [Required] 
        public double breite { get; set; }

        [Required] 
        public double flache { get; set; }

        public ICollection<Gefaehrdung> gefaehrdungs { get; set; }
        [JsonIgnore]
        public ICollection<Beteiligte> beteiligtes { get; set; }
  }
}
