using System.Collections.Generic;
using System.Linq;
using TaxReturn.Core;

namespace TaxReturn.ApplicationServices
{
    public static class AccountTransactionHelper
    {
        public static IEnumerable<AccountTransactionModel> ToAccountTransactionModel(this IEnumerable<AccountTransaction> transactions)
        {
            return transactions.Select(transaction => 
                new AccountTransactionModel(transaction.Account, transaction.Description, 
                    transaction.CurrencyCode, transaction.Amount) {AccountId = transaction.AccountId}).ToList();
        }
    }
}
