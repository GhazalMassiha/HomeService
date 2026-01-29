using Core_HomeService.Domain.Core.ImageAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.ImageAgg.Entities;
using Core_HomeService.Domain.Core.RequestImageAgg.DTOs;
using Core_HomeService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class RequestImageRepository(AppDbContext context) : IRequestImageRepository
    {
        public async Task<List<RequestImageDto>> GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await context.RequestImages
                .AsNoTracking()
                .Where(i => i.RequestId == requestId)
                .Select(i => new RequestImageDto
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    RequestId = i.RequestId

                })
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> Create(RequestImageCreateDto dto, CancellationToken cancellationToken)
        {
            var img = new RequestImage
            {
                RequestId = dto.RequestId,
                ImageUrl = dto.ImageUrl

            };

            await context.RequestImages.AddAsync(img, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var affectedRows = await context.RequestImages
                 .Where(c => c.Id == id)
                 .ExecuteUpdateAsync(setter => setter
                 .SetProperty(c => c.IsDeleted, true),
                     cancellationToken);

            return affectedRows > 0;
        }
    }
}
