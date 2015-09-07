using System;
using System.Data.Entity;
using TaxReturn.Core;

namespace TaxReturn.Repository.Interfaces
{
    public interface IAccountTransactionRepository : IDisposable
    {
        void Save(AccountTransaction transaction);

        IDbSet<AccountTransaction> AccountTransactions { get; set; } 
    }
}
