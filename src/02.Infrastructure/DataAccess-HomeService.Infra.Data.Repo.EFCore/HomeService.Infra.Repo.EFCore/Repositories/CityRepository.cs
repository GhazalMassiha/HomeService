using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Core_HomeService.Domain.Core.CityAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CityAgg.DTOs;
using Core_HomeService.Domain.Core.CityAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class CityRepository(AppDbContext context) : ICityRepository
    {
        public async Task<CityDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Cities
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name

                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<CityWithProvinceDto?> GetByIdWithProvince(int id, CancellationToken cancellationToken)
        {
            return await context.Cities
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CityWithProvinceDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProvinceId = c.ProvinceId

                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<CityDto>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Cities
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name

                }).ToListAsync(cancellationToken);
        }

        public async Task<List<CityWithProvinceDto>> GetAllWithProvince(CancellationToken cancellationToken)
        {
            return await context.Cities
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new CityWithProvinceDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProvinceId = c.ProvinceId

                }).ToListAsync(cancellationToken);
        }

        public async Task<List<CityWithProvinceDto>> GetAllByProvinceId(int provinceId, CancellationToken cancellationToken)
        {
            return await context.Cities
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Where(c => c.ProvinceId == provinceId)
                .Select(c => new CityWithProvinceDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProvinceId = c.ProvinceId

                }).ToListAsync(cancellationToken);
        }

        public async Task<PaginationResult<CityDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Cities
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<PaginationResult<CityWithProvinceDto>> GetAllWithProvincePaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Cities
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new CityWithProvinceDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProvinceId = c.ProvinceId

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<PaginationResult<CityWithProvinceDto>> GetAllByProvinceIdPaged(int provinceId, int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Cities
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Where(c => c.ProvinceId == provinceId)
                .Select(c => new CityWithProvinceDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProvinceId = c.ProvinceId

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Create(CityCreateDto dto, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Name = dto.Name,
                ProvinceId = dto.ProvinceId
            };

            await context.Cities.AddAsync(city, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int id, CityWithProvinceDto dto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Cities
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(c => c.Name, dto.Name)
                .SetProperty(c => c.ProvinceId , dto.ProvinceId) 
                , cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Cities
                 .Where(c => c.Id == id)
                 .ExecuteUpdateAsync(setter => setter
                 .SetProperty(c => c.IsDeleted, true),
                     cancellationToken);

            return affectedRows > 0;
        }
    }
}
