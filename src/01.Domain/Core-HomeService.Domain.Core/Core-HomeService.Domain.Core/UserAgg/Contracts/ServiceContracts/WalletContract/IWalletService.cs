namespace Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.WalletContract
{
    public interface IWalletService
    {
        Task<bool> Charge(int userId, decimal amount, CancellationToken cancellationToken);
        Task<bool> Transfer(int customerUserId, int expertUserId, decimal amount, CancellationToken cancellationToken);
    }
}
