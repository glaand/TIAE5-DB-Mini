﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIAE5_DB_Mini.Models
{
    public class Grundbuchamt : Beteiligte
    {
        public int grundbuchamtId { get; set; }

        public String amtskennung { get; set; }

        public Beteiligte beteiligte { get; set; }
    }
}
