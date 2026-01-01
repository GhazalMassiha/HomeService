using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.DTOs;
using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class ProvinceRepository(AppDbContext context) : IProvinceRepository
    {
        public async Task<ProvinceDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Provinces
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProvinceDto
                {
                    Id = p.Id,
                    Name = p.Name

                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Provinces
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .Select(p => new ProvinceDto
                {
                    Id = p.Id,
                    Name = p.Name

                }).ToListAsync(cancellationToken);
        }

        public async Task<PaginationResult<ProvinceDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Provinces
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .Select(p => new ProvinceDto
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Create(ProvinceCreateDto dto, CancellationToken cancellationToken)
        {
            var province = new Province
            {
                Name = dto.Name
            };

            await context.Provinces.AddAsync(province, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int id, ProvinceDto dto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Provinces
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(p => p.Name, dto.Name)
                , cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var province = await context.Provinces
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (province == null)
                return false;

            province.IsDeleted = true;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
