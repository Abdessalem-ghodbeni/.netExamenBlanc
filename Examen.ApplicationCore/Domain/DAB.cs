using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class DAB
    {
        public string DABid { get; set; }

        public string Localisation { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}
