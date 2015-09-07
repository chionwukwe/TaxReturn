using System.Collections.Generic;
using System.Linq;
using TaxReturn.Core;
using TaxReturn.Models;

namespace TaxReturn.Extensions
{
    public static class AccountTransactionExtensions
    {
        public static IEnumerable<AccountTransactionViewModel> ToAccountTransactionViewModels(this IEnumerable<AccountTransactionModel> transactions)
        {
            return transactions.Select(transaction => 
                new AccountTransactionViewModel(transaction.Account, transaction.Description, 
                    transaction.CurrencyCode, transaction.Amount){AccountId = transaction.AccountId}).ToList();
        }
    }
}