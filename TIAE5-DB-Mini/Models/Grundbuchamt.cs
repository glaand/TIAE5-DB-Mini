using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIAE5_DB_Mini.Models
{
    public class Grundbuchamt : Beteiligte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int grundbuchamtId { get; set; }

        public String amtskennung { get; set; }

        public Beteiligte beteiligte { get; set; }
    }
}
