using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.WalletContract;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.WalletContract
{
    public interface IWalletAppService
    {
        Task<Result<bool>> Charge(int userId, decimal amount, CancellationToken cancellationToken);
        Task<Result<bool>> Transfer(int customerUserId, int expertUserId, decimal amount, CancellationToken cancellationToken);
    }
}
