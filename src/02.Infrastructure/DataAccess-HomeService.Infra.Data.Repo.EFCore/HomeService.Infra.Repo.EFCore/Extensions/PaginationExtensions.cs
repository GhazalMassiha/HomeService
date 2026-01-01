using Core_HomeService.Domain.Core._common;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PaginationResult<T>> ToPaginatedResult<T>(
            this IQueryable<T> query,
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PaginationResult<T>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = items
            };
        }
    }
}
