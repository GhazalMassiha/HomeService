using Azure;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CategoryAgg.DTOs;
using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Core_HomeService.Domain.Core.SubCategoryAgg.DTOs;
using Core_HomeService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.SqlServer.EFCore.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {

        public async Task<CategoryDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Categories
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl

                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<CategoryDto>> GetAll(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl

                })
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> Create(CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = categoryCreateDto.Name,
                ImageUrl = categoryCreateDto.ImageUrl

            };

            await context.Categories.AddAsync(category, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int categoryId, CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Categories
                .Where(c => c.Id == categoryId)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(c => c.Name, categoryCreateDto.Name)
                    .SetProperty(c => c.ImageUrl, categoryCreateDto.ImageUrl),
                    cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int categoryId, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Categories
                .Where(c => c.Id == categoryId)
                .ExecuteDeleteAsync(cancellationToken);

            return affectedRows > 0;
        }
    }
}