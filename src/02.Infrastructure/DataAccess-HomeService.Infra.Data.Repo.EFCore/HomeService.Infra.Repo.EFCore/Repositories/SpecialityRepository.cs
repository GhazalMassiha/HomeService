using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.SubCategoryAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.SubCategoryAgg.DTOs;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.SqlServer.EFCore.Repositories
{
    public class SpecialityRepository(AppDbContext context) : ISpecialityRepository
    {
        public async Task<SpecialityDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Specialities
                .AsNoTracking()
                .Where(sc => sc.Id == id)
                .Select(sc => new SpecialityDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
                    CategoryId = sc.CategoryId

                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<SpecialityDto>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Specialities
                .AsNoTracking()
                .OrderBy(sc => sc.Name)
                .Select(sc => new SpecialityDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
                    CategoryId = sc.CategoryId

                })
                .ToListAsync(cancellationToken);
        }

        public async Task<PaginationResult<SpecialityDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Specialities
                .AsNoTracking()
                .OrderBy(sc => sc.Name)
                .Select(sc => new SpecialityDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
                    CategoryId = sc.CategoryId
                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<List<SpecialityDto>> GetByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            return await context.Specialities
                .AsNoTracking()
                .Where(sc => sc.CategoryId == categoryId)
                .OrderBy(c => c.Name)
                .Select(sc => new SpecialityDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
                    CategoryId = sc.CategoryId

                })
                .ToListAsync(cancellationToken);
        }

        public async Task<PaginationResult<SpecialityDto>> GetByCategoryIdPaged(int page, int pageSize, int categoryId, CancellationToken cancellationToken)
        {
            var query = context.Specialities
                .AsNoTracking()
                .Where(sc => sc.CategoryId == categoryId)
                .OrderBy(c => c.Name)
                .Select(sc => new SpecialityDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
                    CategoryId = sc.CategoryId

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Create(SpecialityCreateDto specialityCreateDto, CancellationToken cancellationToken)
        {
            var speciality = new Speciality
            {
                Name = specialityCreateDto.Name,
                CategoryId = specialityCreateDto.CategoryId,
                Description = specialityCreateDto.Description,
                BasePrice = specialityCreateDto.BasePrice

            };

            await context.Specialities.AddAsync(speciality, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int specialityId, SpecialityCreateDto specialityCreateDto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Specialities
                .Where(sc => sc.Id == specialityId)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(sc => sc.Name, specialityCreateDto.Name)
                    .SetProperty(sc => sc.CategoryId, specialityCreateDto.CategoryId)
                    .SetProperty(sc => sc.Description, specialityCreateDto.Description)
                    .SetProperty(sc => sc.BasePrice, specialityCreateDto.BasePrice),
                    cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int specialityId, CancellationToken cancellationToken)
        {
            var speciality = await context.Specialities
               .FirstOrDefaultAsync(c => c.Id == specialityId, cancellationToken);

            if (speciality == null)
                return false;

            speciality.IsDeleted = true;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}