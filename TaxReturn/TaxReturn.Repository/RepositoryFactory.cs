using TaxReturn.Repository.Interfaces;

namespace TaxReturn.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IAccountTransactionRepository Create()
        {
            return new AccountTransactionDbContext();
        }
    }
}
