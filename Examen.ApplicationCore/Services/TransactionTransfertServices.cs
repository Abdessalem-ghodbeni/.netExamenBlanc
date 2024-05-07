using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class TransactionTransfertServices : Service<TransactionTransfert>, ITransactionTransfert
    {
        public TransactionTransfertServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public double TotaleDab(DAB dAB)
        {
            return GetMany(transaction=>transaction.DABFk==dAB.DABid).Select(transaction=>transaction.Montant).Sum();
        }
    }
}
