using System.Collections.Generic;
using TaxReturn.Core;
using TaxReturn.Repository.Interfaces;

namespace TaxReturn.ApplicationServices
{
    public class QueryAccountTransaction : IQueryAccountTransaction
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public QueryAccountTransaction(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IEnumerable<AccountTransactionModel> GetAll()
        {
            IEnumerable<AccountTransactionModel> result = null;
            using (var context = _repositoryFactory.Create())
            {
                result = context.AccountTransactions.ToAccountTransactionModel();
            }
            return result;
        }
    }
}
