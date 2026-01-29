using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.WalletContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.WalletContract;

namespace Service_HomeService.Domain.Service.Services
{
    public class WalletService(IWalletRepository walletRepository) : IWalletService
    {
        public async Task<bool> Charge(int userId, decimal amount, CancellationToken cancellationToken)
        {
            return await walletRepository.Charge(userId, amount, cancellationToken);
        }

        public async Task<bool> Transfer(int customerUserId, int expertUserId, decimal amount, CancellationToken cancellationToken)
        {
            return await walletRepository.Transfer(customerUserId, expertUserId, amount, cancellationToken);
        }
    }
}
