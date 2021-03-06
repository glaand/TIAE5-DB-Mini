using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIAE5_DB_Mini.Models
{
    [Table("eigentuemer")]
    public class Eigentuemer : Beteiligte
    {
        public int eigentuemerId { get; set; }

        [Required]
        public bool juristischePerson { get; set; }

        public Beteiligte beteiligtes { get; set; }
    }
}
