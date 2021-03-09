using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIAE5_DB_Mini.Models
{
    public class Beteiligte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int beteiligteId { get; set; }

        [Required]
        public String email { get; set; }

        [Required]
        public String telefon { get; set; }

        public ICollection<Objekt> objekts { get; set; }
    }
}
