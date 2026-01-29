using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ExpertDTOs;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class ExpertRepository(AppDbContext context) : IExpertRepository
    {
        public async Task<ExpertDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Experts
                .Include(c => c.User)
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new ExpertDto
                {
                    Id = c.Id,
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Email = c.User.Email,
                    Biography = c.Biography,
                    Rating = c.Rating,
                    CityId = c.User.CityId,
                    ProvinceId = c.User.ProvinceId,
                    AccountBalance = c.User.AccountBalance,
                    ImageUrl = c.User.ImageUrl

                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginationResult<ExpertDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Experts
                .Include(c => c.User)
                .AsNoTracking()
                .OrderBy(c => c.Id)
                .Select(c => new ExpertDto
                {
                    Id = c.Id,
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Email = c.User.Email,
                    Biography = c.Biography,
                    Rating = c.Rating,
                    CityId = c.User.CityId,
                    ProvinceId = c.User.ProvinceId,
                    AccountBalance = c.User.AccountBalance,
                    ImageUrl = c.User.ImageUrl

                });


            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Update(int id, ExpertUpdateDto dto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Experts
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(c => c.User.FirstName, dto.FirstName)
                    .SetProperty(c => c.User.LastName, dto.LastName)
                    .SetProperty(c => c.Biography, dto.Biography)
                    .SetProperty(c => c.CardNumber, dto.CardNumber)
                    .SetProperty(c => c.User.CityId, dto.CityId)
                    .SetProperty(c => c.User.ProvinceId, dto.ProvinceId)
                    .SetProperty(c => c.User.ImageUrl, dto.ImageUrl),
                    cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var expert = await context.Experts
                 .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (expert == null)
                return false;

            expert.IsDeleted = true;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
