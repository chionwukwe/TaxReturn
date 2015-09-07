using System.Data.Entity;
using TaxReturn.Core;
using TaxReturn.Repository.Interfaces;


namespace TaxReturn.Repository
{
    public class AccountTransactionDbContext : DbContext, IAccountTransactionRepository
    {
        public void Save(AccountTransaction transaction)
        {
            AccountTransactions.Add(transaction);
            base.SaveChanges();
        }

        public IDbSet<AccountTransaction> AccountTransactions { get; set; }
    }
}
