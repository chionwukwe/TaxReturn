using System.Collections.Generic;

namespace TaxReturn.Core
{
    public interface IQueryAccountTransaction
    {
        IEnumerable<AccountTransactionModel> GetAll();
    }
}
