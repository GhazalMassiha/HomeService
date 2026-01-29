using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.WalletContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.WalletContract;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class WalletAppService(IWalletService walletService) : IWalletAppService
    {
        public async Task<Result<bool>> Charge(int userId, decimal amount, CancellationToken cancellationToken)
        {
            if (amount <= 0)
                return Result<bool>.Failure("مبلغ شارژ باید بیشتر از صفر باشد.");

            var ok = await walletService.Charge(userId, amount, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("شارژ کیف پول ناموفق بود.");

            return Result<bool>.Success("کیف پول با موفقیت شارژ شد.", true);
        }

        public async Task<Result<bool>> Transfer(int customerUserId, int expertUserId, decimal amount, CancellationToken cancellationToken)
        {
            if (amount <= 0)
                return Result<bool>.Failure("مبلغ انتقال نامعتبر است.");

            var ok = await walletService.Transfer(customerUserId, expertUserId, amount, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("انتقال وجه ناموفق بود.");

            return Result<bool>.Success("انتقال وجه با موفقیت انجام شد.", true);
        }
    }
}
