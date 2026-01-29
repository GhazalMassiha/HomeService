namespace Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.WalletContract
{
    public interface IWalletRepository
    {
        Task<bool> Charge(int userId, decimal amount, CancellationToken cancellationToken);
        Task<bool> Transfer(int customerUserId, int expertUserId, decimal amount, CancellationToken cancellationToken);
    }
}
