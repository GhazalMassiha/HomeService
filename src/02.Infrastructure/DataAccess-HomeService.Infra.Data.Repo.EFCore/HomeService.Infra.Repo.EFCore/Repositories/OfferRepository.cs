using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.OfferAgg.DTOs;
using Core_HomeService.Domain.Core.OfferAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class OfferRepository(AppDbContext context) : IOfferRepository
    {
        public async Task<OfferDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Offers
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new OfferDto
                {
                    Id = o.Id,
                    ExpertId = o.ExpertId,
                    RequestId = o.RequestId,
                    Price = o.Price,
                    Text = o.Text,
                    Status = o.Status

                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginationResult<OfferDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Offers
                .AsNoTracking()
                .OrderByDescending(o => o.Id)
                .Select(o => new OfferDto
                {
                    Id = o.Id,
                    ExpertId = o.ExpertId,
                    RequestId = o.RequestId,
                    Price = o.Price,
                    Text = o.Text,
                    Status = o.Status

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Create(OfferCreateDto dto, CancellationToken cancellationToken)
        {
            var offer = new Offer
            {
                ExpertId = dto.ExpertId,
                RequestId = dto.RequestId,
                Price = dto.Price,
                Text = dto.Text,
                Status = dto.Status
            };

            await context.Offers.AddAsync(offer, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int id, OfferUpdateDto dto, CancellationToken cancellationToken)
        {
            var affected = await context.Offers
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(o => o.Price, dto.Price)
                    .SetProperty(o => o.Text, dto.Text),
                    cancellationToken);

            return affected > 0;
        }

        public async Task<bool> UpdateStatus(int id, OfferStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            var affected = await context.Offers
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(o => o.Status, dto.Status),
                    cancellationToken);

            return affected > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var offer = await context.Offers
                 .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (offer == null) 
                return false;

            offer.IsDeleted = true;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
