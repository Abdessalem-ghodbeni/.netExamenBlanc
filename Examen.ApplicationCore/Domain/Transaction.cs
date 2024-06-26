﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }

        public double Montant { get; set; }
        [ForeignKey("DAB")]
        public string DABFk { get; set; }
        [ForeignKey("Compte")]
        public string NumeroCompteFk { get; set; }
        public virtual Compte Compte { get; set; }
        public virtual DAB DAB{ get; set; }


    }
}
