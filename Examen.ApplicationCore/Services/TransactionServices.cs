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
    public class TransactionServices : Service<Transaction>, ITransactionServices
    {
     
public TransactionServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double nombreTransaction(Compte compte)
        {
            DateTime currentDate = DateTime.Now;
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            int totalTransactions = compte.Transactions
                .Count(t => t.Date >= startOfWeek && t.Date <= endOfWeek);

            return totalTransactions;
        }

        public List<Transaction> TransactionsListe(DateTime date)
        {
            return GetMany(t=>t.Date==date && t.Compte.Type.Equals(TypeCompte.Epargne)).ToList();
        }
    }
}
