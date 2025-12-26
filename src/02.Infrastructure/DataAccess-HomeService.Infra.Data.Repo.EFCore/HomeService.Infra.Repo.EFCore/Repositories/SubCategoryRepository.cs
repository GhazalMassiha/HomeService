using Core_HomeService.Domain.Core.SubCategoryAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.SubCategoryAgg.DTOs;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.SqlServer.EFCore.Repositories
{
    public class SubCategoryRepository(AppDbContext context) : ISubCategoryRepository
    {
        public async Task<SubCategoryDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.SubCategories
                .AsNoTracking()
                .Where(sc => sc.Id == id)
                .Select(sc => new SubCategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryId = sc.CategoryId

                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<SubCategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return await context.SubCategories
                .AsNoTracking()
                .Select(sc => new SubCategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryId = sc.CategoryId

                })
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> Create(SubCategoryCreateDto subCategoryCreateDto, CancellationToken cancellationToken)
        {
            var subCategory = new SubCategory
            {
                Name = subCategoryCreateDto.Name,
                CategoryId = subCategoryCreateDto.CategoryId

            };

            await context.SubCategories.AddAsync(subCategory, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int subCategoryId, SubCategoryCreateDto subCategoryCreateDto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.SubCategories
                .Where(sc => sc.Id == subCategoryId)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(sc => sc.Name, subCategoryCreateDto.Name)
                    .SetProperty(sc => sc.CategoryId, subCategoryCreateDto.CategoryId),
                    cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int subCategoryId, CancellationToken cancellationToken)
        {
            var affectedRows = await context.SubCategories
                .Where(sc => sc.Id == subCategoryId)
                .ExecuteDeleteAsync(cancellationToken);

            return affectedRows > 0;
        }
    }
}