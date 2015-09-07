using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TaxReturn.Core
{
    public class AccountTransaction
    {
        public AccountTransaction()
        {
            
        }
        public AccountTransaction(string account, string description, string currencyCode, string amount)
        {
            Account = account;
            Description = description;
            CurrencyCode = currencyCode;
            Amount = amount;
            ErrorMessages = new List<string>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        public string Account { get; private set; }
        public string Description { get; set; }

        public string CurrencyCode { get; set; }

        public string Amount { get; set; }

        public bool Valid()
        {
            if(String.IsNullOrEmpty(Account)) ErrorMessages.Add("Account Name is required");
            if(String.IsNullOrEmpty(Description)) ErrorMessages.Add("Description is missing");
            if(String.IsNullOrEmpty(CurrencyCode)) ErrorMessages.Add("Currency Code is Missing");
            string currencySymbol;
            if(!CurrencyTools.TryGetCurrencySymbol(CurrencyCode, out currencySymbol)) ErrorMessages.Add("Invalid currency code");
            decimal result;
            if(!Decimal.TryParse(Amount, out result)) ErrorMessages.Add("Amount must be a valid number");
            
            return !ErrorMessages.Any();
        }

        [NotMapped]
        public List<string> ErrorMessages { get; private set; }
    }
}
