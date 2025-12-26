using Core_HomeService.Domain.Core.SubCategoryAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.SubCategoryAgg.DTOs;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
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
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
                    CategoryId = sc.CategoryId

                })
                .ToListAsync(cancellationToken);
        }

        public async Task<List<SubCategoryDto>> GetByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            return await context.SubCategories
                .AsNoTracking()
                .Where(sc => sc.CategoryId  == categoryId)
                .Select(sc => new SubCategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    Description = sc.Description,
                    BasePrice = sc.BasePrice,
                    CategoryId = sc.CategoryId

                })
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> Create(SubCategoryCreateDto subCategoryCreateDto, CancellationToken cancellationToken)
        {
            var subCategory = new SubCategory
            {
                Name = subCategoryCreateDto.Name,
                CategoryId = subCategoryCreateDto.CategoryId,
                Description = subCategoryCreateDto.Description,
                BasePrice = subCategoryCreateDto.BasePrice

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
                    .SetProperty(sc => sc.CategoryId, subCategoryCreateDto.CategoryId)
                    .SetProperty(sc => sc.Description, subCategoryCreateDto.Description)
                    .SetProperty(sc => sc.BasePrice, subCategoryCreateDto.BasePrice),
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