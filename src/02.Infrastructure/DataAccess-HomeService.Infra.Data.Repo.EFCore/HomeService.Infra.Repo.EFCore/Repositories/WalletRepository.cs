using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.WalletContract;
using Core_HomeService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class WalletRepository(AppDbContext context) : IWalletRepository
    {
        public async Task<bool> Charge(int userId, decimal amount, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(setter =>setter
                .SetProperty(u => u.AccountBalance, u => u.AccountBalance + amount),
                    cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Transfer(int customerUserId, int expertUserId, decimal amount, CancellationToken cancellationToken)
        {
            if (amount <= 0)
                return false;

            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            var customerBalanceResult = await context.Users
                .Where(u => u.Id == customerUserId && u.AccountBalance >= amount)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(
                        u => u.AccountBalance,
                        u => u.AccountBalance - amount),
                    cancellationToken);

            if (customerBalanceResult == 0)
            {
                await transaction.RollbackAsync(cancellationToken);
                return false;
            }

            var expertBalanceResult = await context.Users
                .Where(u => u.Id == expertUserId)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(
                        u => u.AccountBalance,
                        u => u.AccountBalance + amount),
                    cancellationToken);

            if (expertBalanceResult == 0)
            {
                await transaction.RollbackAsync(cancellationToken);
                return false;
            }

            await transaction.CommitAsync(cancellationToken);

            return true;
        }
    }
}
