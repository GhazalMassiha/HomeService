using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.RequestAgg.DTOs;
using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class RequestRepository(AppDbContext context) : IRequestRepository
    {
        public async Task<RequestDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Requests
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new RequestDto
                {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    ProvinceId = r.ProvinceId,
                    CityId = r.CityId,
                    Title = r.Title,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedAt = r.CreatedAt,
                    ScheduledAt = r.ScheduledAt

                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginationResult<RequestDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Requests
                .AsNoTracking()
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new RequestDto
                {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    ProvinceId = r.ProvinceId,
                    CityId = r.CityId,
                    Title = r.Title,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedAt = r.CreatedAt,
                    ScheduledAt = r.ScheduledAt

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<PaginationResult<RequestDto>> GetByCustomerIdPaged(int page, int pageSize, int customerId, CancellationToken cancellationToken)
        {
            var query = context.Requests
                .AsNoTracking()
                .Where(r => r.CustomerId == customerId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new RequestDto
                {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    ProvinceId = r.ProvinceId,
                    CityId = r.CityId,
                    Title = r.Title,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedAt = r.CreatedAt,
                    ScheduledAt = r.ScheduledAt

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<PaginationResult<RequestDto>> GetByCategoryIdPaged(int page, int pageSize, int categoryId, CancellationToken cancellationToken)
        {
            var query = context.Requests
                .AsNoTracking()
                .Where(r => r.CategoryId == categoryId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new RequestDto
                {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    ProvinceId = r.ProvinceId,
                    CityId = r.CityId,
                    Title = r.Title,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedAt = r.CreatedAt,
                    ScheduledAt = r.ScheduledAt

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<PaginationResult<RequestDto>> GetBySpecialityIdPaged(int page, int pageSize, int specialityId, CancellationToken cancellationToken)
        {
            var query = context.Requests
                .AsNoTracking()
                .Where(r => r.SpecialityId == specialityId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new RequestDto
                {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    ProvinceId = r.ProvinceId,
                    CityId = r.CityId,
                    Title = r.Title,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedAt = r.CreatedAt,
                    ScheduledAt = r.ScheduledAt

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Create(RequestCreateDto dto, CancellationToken cancellationToken)
        {
            var request = new Request
            {
                CustomerId = dto.CustomerId,
                ProvinceId = dto.ProvinceId,
                CityId = dto.CityId,
                Title = dto.Title,
                Description = dto.Description,
                ScheduledAt = dto.ScheduledAt
            };

            await context.Requests.AddAsync(request, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int id, RequestUpdateDto dto, CancellationToken cancellationToken)
        {
            var affected = await context.Requests
                .Where(r => r.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(r => r.Title, dto.Title)
                    .SetProperty(r => r.Description, dto.Description)
                    .SetProperty(r => r.ScheduledAt, dto.ScheduledAt),
                    cancellationToken);

            return affected > 0;
        }

        public async Task<bool> UpdateStatus(int id, RequestStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            var affected = await context.Requests
                .Where(r => r.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(r => r.Status, dto.Status),
                    cancellationToken);

            return affected > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Requests
                 .Where(c => c.Id == id)
                 .ExecuteUpdateAsync(setter => setter
                 .SetProperty(c => c.IsDeleted, true),
                     cancellationToken);

            return affectedRows > 0;
        }
    }

}
