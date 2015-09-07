namespace TaxReturn.Repository.Interfaces
{
    public interface IRepositoryFactory
    {
        IAccountTransactionRepository Create();
    }
}
