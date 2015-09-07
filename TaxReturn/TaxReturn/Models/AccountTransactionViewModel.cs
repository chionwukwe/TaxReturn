
namespace TaxReturn.Models
{
    public class AccountTransactionViewModel
    {
        public AccountTransactionViewModel(string account, string description, string currencyCode, string amount)
        {
            Account = account;
            Description = description;
            CurrencyCode = currencyCode;
            Amount = amount;
        }
        public int AccountId { get; set; }

        public string Account { get; private set; }
        public string Description { get; set; }

        public string CurrencyCode { get; set; }

        public string Amount { get; set; }
    }
}